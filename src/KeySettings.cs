using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Configuration;
using Unity.Baselib.LowLevel;
using UnityEngine;

namespace RemapHotkeys
{
    public class KeySettings
    {
        public ConfigEntry<KeyboardShortcut> ScrollLeftKey;
        public ConfigEntry<KeyboardShortcut> ScrollRightKey;

        public ConfigEntry<KeyboardShortcut> ScrollStartKey;
        public ConfigEntry<KeyboardShortcut> ScrollEndKey;

        public ConfigEntry<KeyboardShortcut> LocationScrollLeftKey;
        public ConfigEntry<KeyboardShortcut> LocationScrollRightKey;

        public ConfigEntry<KeyboardShortcut> LocationScrollStart;
        public ConfigEntry<KeyboardShortcut> LocationScrollEnd;

        public KeyCode CharacterEquipmentKey;
        public KeyCode CharacterKey;
        public KeyCode HealthKey;
        public KeyCode BlueprintScreenKey;
        public KeyCode ConfirmActionKey;
        public KeyCode ExitScreenKey;
        public KeyCode WaitingOptionsKey;
        public KeyCode JournalKey;
        public KeyCode StatsKey;



        public void SetConfigValues(ConfigFile config)
        {
            const string sectionName = "Keys";
            
            ScrollLeftKey = config.Bind(sectionName, nameof(ScrollLeftKey), new KeyboardShortcut(KeyCode.A), "Scroll left for most card lines");
            ScrollRightKey = config.Bind(sectionName, nameof(ScrollRightKey), new KeyboardShortcut(KeyCode.S), "Scroll right for most card lines");
            ScrollStartKey = config.Bind(sectionName, nameof(ScrollStartKey), new KeyboardShortcut(KeyCode.A, KeyCode.LeftShift), 
                "Scroll to the start for most card lines");
            ScrollEndKey = config.Bind(sectionName, nameof(ScrollEndKey), new KeyboardShortcut(KeyCode.S, KeyCode.LeftShift), 
                "Scroll to the start for most card lines");

            LocationScrollStart = config.Bind(sectionName, nameof(LocationScrollStart), new KeyboardShortcut(KeyCode.Q, KeyCode.LeftShift),
                "Scroll to the start of the location.");
            LocationScrollEnd = config.Bind(sectionName, nameof(LocationScrollEnd), new KeyboardShortcut(KeyCode.W, KeyCode.LeftShift), "Scroll to the end of the location");
            LocationScrollLeftKey = config.Bind(sectionName, nameof(LocationScrollLeftKey), new KeyboardShortcut(KeyCode.Q), "Scroll left for location cards");
            LocationScrollRightKey = config.Bind(sectionName, nameof(LocationScrollRightKey), new KeyboardShortcut(KeyCode.W), "Scroll Right for location cards");

            CharacterEquipmentKey = config.Bind(sectionName, nameof(CharacterEquipmentKey), KeyCode.E, "Open the Character Equipment screen").Value;
            CharacterKey = config.Bind(sectionName, nameof(CharacterKey), KeyCode.C, "Open the Character screen").Value;
            BlueprintScreenKey = config.Bind(sectionName, nameof(BlueprintScreenKey), KeyCode.B, "Open the Blueprint screen").Value;
            ConfirmActionKey = config.Bind(sectionName, nameof(ConfirmActionKey), KeyCode.Space, "Accept the dialog's left most action").Value;
            ExitScreenKey = config.Bind(sectionName, nameof(ExitScreenKey), KeyCode.Escape, "Close the current dialog").Value;
            WaitingOptionsKey = config.Bind(sectionName, nameof(WaitingOptionsKey), KeyCode.T, "Opens the Waiting Options dialog (rest/sleep, etc.)").Value;
            JournalKey = config.Bind(sectionName, nameof(JournalKey), KeyCode.J, "Opens the Journal dialog").Value;
            HealthKey = config.Bind(sectionName, nameof(HealthKey), KeyCode.H, "Opens the Character Wounds dialog").Value;
            StatsKey = config.Bind(sectionName, nameof(StatsKey), KeyCode.D, "Opens the Character Stats Dialog").Value;
        }
    }
}
