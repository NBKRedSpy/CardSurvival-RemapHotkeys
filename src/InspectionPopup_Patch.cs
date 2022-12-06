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
                if (__instance.TrashConfirm.activeInHierarchy || __instance.SelectBookmarkPopup.activeInHierarchy ||
                    __instance.RenamePopup.activeInHierarchy)
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
                    //This is most of the dialogs.  There are an array of pre-made buttons, which some are
                    //  dynamically set with text when needed.
                    DismantleActionButton button = ___OptionsButtons.FirstOrDefault(x => x.isActiveAndEnabled);

                    //DismantleActionButton note:
                    //  These buttons are odd since the visible buttons are set to enabled, interactable, etc.
                    //  However the ConditionsValid property indicates if the user can invoke the action.

                    //Always trying to click the first active button.  
                    //  If one is invalid, all should be.  For consistency, only checking the first
                    //  visible button.
                    if (button != null && button.ConditionsValid)
                    {
                        button.Click();
                        __runOriginal = false;
                    }
                }
            }

        }
    }
}
