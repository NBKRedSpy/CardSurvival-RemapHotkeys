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
        public static Button BlueprintAutoFillButton;

        public static void Prefix(GraphicsManager __instance, ref bool __runOriginal)
        {

            //Do not execute hotkeys if the user is in the guide screen.  It interferes with the search
            if (GraphicsManager.PlayerIsTyping)
            {
                return;
            }

            if (Input.GetKeyDown(Plugin.KeySettings.ConfirmActionKey))
            {
                //The confirmation side of the counter.  Where things can be stolen.
                if (CardDestoryButton == null)
                {
                    CardDestoryButton = GameObject.Find(
                        "MainCanvas/TooltipRect/DestroyedCardsPopup/ShadowAndPopupWithTitle/Content/Content/ButtonBase/ButtonObject")
                        .GetComponent<Button>();
                }


                if (CardDestoryButton.isActiveAndEnabled && CardDestoryButton.IsInteractable())
                {
                    CardDestoryButton.onClick.Invoke();
                    __runOriginal = false;
                    return;
                }
                else if(__instance.BlueprintPopup.gameObject.activeInHierarchy)
                {
                    //The blueprint construction screen.  Located at the location bar.

                    if (BlueprintAutoFillButton == null)
                    {
                        BlueprintAutoFillButton = (Button)AccessTools.Field(typeof(BlueprintConstructionPopup), "AutoFillButton")
                            .GetValue(__instance.BlueprintPopup);
                    }

                    if (BlueprintAutoFillButton.isActiveAndEnabled && BlueprintAutoFillButton.IsInteractable())
                    {
                        BlueprintAutoFillButton.onClick.Invoke();
                        __runOriginal = false;
                        return;
                    }
                }
            }


        }
    }

    [HarmonyPatch(typeof(GraphicsManager), nameof(GraphicsManager.Init))]
    public static class GraphicsManager_Init_Patch
    {
        public static void Postfix(GraphicsManager __instance)
        {
            __instance.CanOpenMenu = !Plugin.DisableMenuOnExitKey;
        }
    }
}



