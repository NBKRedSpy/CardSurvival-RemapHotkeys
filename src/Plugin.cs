using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace RemapHotkeys
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInIncompatibility("RepeatScroll")]
    public class Plugin : BaseUnityPlugin
    {
        public static ManualLogSource Log { get; set; }

        public static ConfigEntry<bool> EnableScrollRepeat { get; private set; }

        public static ConfigEntry<int> RepeatScrollMilliseconds { get; private set; }

        public static KeySettings KeySettings { get; private set; }
        public static bool DisableMenuOnExitKey { get; private set; }

        private void Awake()
        {

            Log = Logger;
            KeySettings = new KeySettings();
            KeySettings.SetConfigValues(Config);

            DisableMenuOnExitKey = Config.Bind("Options", nameof(DisableMenuOnExitKey), false,
                "If true, will prevent the game's menu from displaying when pressing the Exit Screen hotkey.").Value;

            EnableScrollRepeat = Config.Bind("Options", nameof(EnableScrollRepeat), true,
                "If true, holding the scroll key will continue to scroll the line");

            RepeatScrollMilliseconds = Config.Bind("Options", nameof(RepeatScrollMilliseconds), 500,
                "How long a scroll key must be held down to repeat a scroll operation");

            SetReloadableSettings();

            Config.SettingChanged += Config_SettingChanged;

            StartEnd_GraphicsManager_Hotkeys_Patch.KeyRepeatCheck.RepeatMilliseconds = RepeatScrollMilliseconds.Value;

            Harmony harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
            harmony.PatchAll();

        }

        private void SetReloadableSettings()
        {
            StartEnd_GraphicsManager_Hotkeys_Patch.KeyRepeatCheck.RepeatMilliseconds = RepeatScrollMilliseconds.Value;
        }
        private void Config_SettingChanged(object sender, SettingChangedEventArgs e)
        {
            SetReloadableSettings();
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