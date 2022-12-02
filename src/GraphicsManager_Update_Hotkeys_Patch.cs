using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace RemapHotkeys
{

    [HarmonyPatch(typeof(GraphicsManager), "Update")]
    public static class GraphicsManager_Update_Hotkeys_Patch
    {

        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            KeySettings keySettings = Plugin.KeySettings;

            return new CodeMatcher(instructions)
                .RemapKey(KeyCode.Escape, keySettings.ExitScreenKey)
                .InstructionEnumeration();
        }

    }



    /// <summary>
    /// Confirm action for Encounter
    /// </summary>
    [HarmonyPatch(typeof(GraphicsManager), "Update")]
    public static class GraphicsManager_Update_Patch
    {
        private static Button CardDestoryButton;

        public static void Prefix(InspectionPopup __instance)
        {
            //Do not execute hotkeys if the user is in the guide screen.  It interferes with the search
            if (GraphicsManager.PlayerIsTyping)
            {
                return;
            }
            else if (Input.GetKeyDown(Plugin.KeySettings.ConfirmActionKey))
            {
                //Encounter screen.  For example, Seagull raid.
                if (CardDestoryButton == null)
                {
                    CardDestoryButton = GameObject.Find(
                        "MainCanvas/TooltipRect/DestroyedCardsPopup/ShadowAndPopupWithTitle/Content/Content/ButtonBase/ButtonObject")
                        .GetComponent<Button>();
                }

                if (CardDestoryButton.isActiveAndEnabled && CardDestoryButton.IsInteractable())
                {
                    CardDestoryButton.onClick.Invoke();
                }
            }


        }
    }
}



