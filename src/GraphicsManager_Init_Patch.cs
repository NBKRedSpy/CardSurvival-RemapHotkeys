using HarmonyLib;

namespace RemapHotkeys
{
    [HarmonyPatch(typeof(GraphicsManager), nameof(GraphicsManager.Init))]
    public static class GraphicsManager_Init_Patch
    {
        public static void Postfix(GraphicsManager __instance)
        {
            __instance.CanOpenMenu = !Plugin.DisableMenuOnExitKey;
        }
    }
}



