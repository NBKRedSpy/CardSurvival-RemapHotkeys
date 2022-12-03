using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                return;

            else if (Input.GetKeyDown(Plugin.KeySettings.ConfirmActionKey))
            {
                Button emptyInventoryButton = __instance.EmptyInventoryButton;
                //Check for a container screen.
                if ( emptyInventoryButton  != null)
                {
                    //Assume the user wants to empty.
                    if (emptyInventoryButton.isActiveAndEnabled && emptyInventoryButton.interactable)
                    {
                        emptyInventoryButton.onClick.Invoke();
                        __runOriginal = false;
                    }

                    //All other actions are ignored.  They should be dissasemble or put out fire, etc.
                    return;
                }
                else
                {
                    //This is most of the dialogs.  There are an array of premade buttons, which some are
                    //  dynamically set with text when needed.
                    DismantleActionButton button = ___OptionsButtons.FirstOrDefault(x => x.isActiveAndEnabled);

                    if (button != null)
                    {
                        button.Click();
                        //button.OnClicked.Invoke(0);
                        __runOriginal = false;
                    }
                }
            }

        }
    }
}
