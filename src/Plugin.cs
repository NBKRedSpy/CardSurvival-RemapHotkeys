using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace RemapHotkeys
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static ManualLogSource Log { get; set; }

        public static KeySettings KeySettings { get; private set; }
        public static bool DisableMenuOnExitKey { get; private set; }

        private void Awake()
        {

            Log = Logger;
            KeySettings = new KeySettings();
            KeySettings.SetConfigValues(Config);

            DisableMenuOnExitKey = Config.Bind("Options", nameof(DisableMenuOnExitKey), false,
                "If true, will prevent the game's menu from displaying when pressing the Exit Screen hotkey.").Value;

            Harmony harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
            harmony.PatchAll();

        }

        public static void LogInfo(string text)
        {
            Plugin.Log.LogInfo(text);
        }

        public static string GetGameObjectPath(GameObject obj)
        {
            GameObject searchObject = obj;

            string path = "/" + searchObject.name;
            while (searchObject.transform.parent != null)
            {
                searchObject = searchObject.transform.parent.gameObject;
                path = "/" + searchObject.name + path;
            }
            return path;
        }

    }
}