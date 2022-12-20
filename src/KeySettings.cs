using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Configuration;
using UnityEngine;

namespace RemapHotkeys
{
    public class KeySettings
    {
        public KeyCode ScrollLeftKey;
        public KeyCode ScrollRightKey;
        public KeyCode LocationScrollLeftKey;
        public KeyCode LocationScrollRightKey;
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
            ScrollLeftKey = config.Bind(sectionName, nameof(ScrollLeftKey), KeyCode.A, "Scroll left for most card lines").Value;
            ScrollRightKey = config.Bind(sectionName, nameof(ScrollRightKey), KeyCode.S, "Scroll right for most card lines").Value;
            LocationScrollLeftKey = config.Bind(sectionName, nameof(LocationScrollLeftKey), KeyCode.Q, "Scroll left for location cards").Value;
            LocationScrollRightKey = config.Bind(sectionName, nameof(LocationScrollRightKey), KeyCode.W, "Scroll Right for location cards").Value;
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
