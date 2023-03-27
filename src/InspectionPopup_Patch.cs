using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace RemapHotkeys
{


    /// <summary>
    /// Handles the majority of the popup type dialogs.  Extracting coconut fibers, 
    /// wildlife encounters, climbing trees, etc.
    /// </summary>
    [HarmonyPatch(typeof(InspectionPopup), "Update")]
    public static class InspectionPopup_Patch
    {
        public static void Prefix(InspectionPopup __instance, List<DismantleActionButton> ___OptionsButtons, ref bool __runOriginal)
        {

            //Do not execute hotkeys if the user is in the guide screen.  It interferes with the search
            if (GraphicsManager.PlayerIsTyping)
            {
                return;
            }
            else if (Input.GetKeyDown(Plugin.KeySettings.ConfirmActionKey))
            {

                //The additional action buttons are their own rectangles that cover the entire dialog and have a 
                //transparent background.  This means that the main inspection buttons are active, but the user
                //is prevented from clicking them by the transparent sub popup.
                //
                //Not sure how to detect this.  Best that I know how to do 
                //being enabled.


                if ((__instance?.TrashConfirm?.activeInHierarchy ?? false) || (__instance?.SelectBookmarkPopup?.activeInHierarchy ?? false) ||
                   (__instance?.RenamePopup?.activeInHierarchy ?? false))
                {

                    //One of the sub popup windows are being shown.  Exit
                    return;
                }


                Button emptyInventoryButton = __instance.EmptyInventoryButton;
                //Check for a container screen.
                if (emptyInventoryButton != null)
                {
                    //Assume the user wants to empty.
                    if (emptyInventoryButton.isActiveAndEnabled && emptyInventoryButton.interactable)
                    {
                        emptyInventoryButton.onClick.Invoke();
                        __runOriginal = false;
                    }

                    //All other actions are ignored.  They should be disassemble or put out fire, etc.
                    return;
                }
                else
                {

                    //-- Check for dig up mud

                    //  There might be a way to link the button's action event to the card's actions, but
                    //not sure.  Using localized text match to button text for now.  It works.

                    //The Puddle_DismantleActions[0].ActionName seems to really be the localization key.  
                    //  odd, but seems to be correct.

                    //Note - Finding "Dig up Mud" action with localized text: 
                    //  In the code, there is not a link between the Option Button 
                    //and the localization key/text.  It only sets the localized text.  
                    //  So, trying to get the button text from the localized string, which should exactly match
                    //the text on the option button.

                    DismantleCardAction digUpMudCardAction = __instance?.CurrentCard?.DismantleActions
                        .FirstOrDefault(x => x.ActionName.LocalizationKey == "Puddle_DismantleActions[0].ActionName");


                    DismantleActionButton targetButton = null;

                    if (digUpMudCardAction != null)
                    {

                        string digMudText = (string)digUpMudCardAction.ActionName;

                        targetButton = ___OptionsButtons.FirstOrDefault(actionButton => actionButton != null && actionButton.isActiveAndEnabled
                            &&  actionButton.Text == (string)digUpMudCardAction.ActionName);

                        if(targetButton == null || targetButton.ConditionsValid == false)
                        {
                            //Try the first action if the button cannot be clicked.
                            targetButton = null;
                        }


                    }
                    else
                    {

                        //This is most of the dialogs.  There are an array of pre-made buttons, which some are
                        //  dynamically set with text when used.

                        targetButton = ___OptionsButtons.FirstOrDefault(x => x.isActiveAndEnabled);
                        //DismantleActionButton note:
                        //  These buttons are odd since the visible buttons are set to enabled, interactable, etc.
                        //  However the ConditionsValid property indicates if the user can invoke the action.

                        //Always trying to click the first active button.  
                        //  If one is invalid, all should be.  For consistency, only checking the first
                        //  visible button.
                    }

                    if (targetButton != null && targetButton.ConditionsValid)
                    {

                        targetButton.Click();
                        __runOriginal = false;
                    }
                }
            }

        }
    }
}
