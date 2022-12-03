using HarmonyLib;
using UnityEngine;

namespace RemapHotkeys
{
    [HarmonyPatch(typeof(GraphicsManager), "EscKeyPressed")]
    public static class GraphicsManager_HelpClose_Patch
    {

        public static void Prefix(ref bool __runOriginal) 
        {
            //Prevent the Exit key from closing help if it is not escape.
            if (Plugin.KeySettings.ExitScreenKey != KeyCode.Escape)
            {
                if(GraphicsManager.PlayerIsTyping)
                {
                    __runOriginal = false;
                }
            }
        }

    }
}
