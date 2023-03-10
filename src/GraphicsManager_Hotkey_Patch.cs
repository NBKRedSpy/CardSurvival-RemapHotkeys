using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UIElements.UIR;

namespace RemapHotkeys
{
    [HarmonyPatch(typeof(GraphicsManager), "Hotkeys")]
    public static class GraphicsManager_Hotkey_Patch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {

            KeySettings keySettings = Plugin.KeySettings;

            return new CodeMatcher(instructions)
                //Removed - Handled by prefix patch, but need to blank them out to prevent collision.
                .RemapKey(KeyCode.Q, KeyCode.None)
                .RemapKey(KeyCode.W, KeyCode.None)
                .RemapKey(KeyCode.A, KeyCode.None)
                .RemapKey(KeyCode.S, KeyCode.None)
                
                
                //--The remainder of the mapping.
                .RemapKey(KeyCode.B, keySettings.BlueprintScreenKey)
                .RemapKey(KeyCode.J, keySettings.JournalKey)
                .RemapKey(KeyCode.E, keySettings.CharacterEquipmentKey)
                .RemapKey(KeyCode.H, keySettings.HealthKey)

                .RemapKey(KeyCode.C, keySettings.CharacterKey)
                .RemapKey(KeyCode.T , keySettings.WaitingOptionsKey)
                .RemapKey(KeyCode.D , keySettings.StatsKey)
                .InstructionEnumeration();
        }

        public static CodeMatcher RemapKey(this CodeMatcher codeMatcher, KeyCode fromKey, KeyCode toKey)
        {
            return codeMatcher
                .MatchForward(false, new CodeMatch(OpCodes.Ldc_I4_S, (sbyte)fromKey))
                .ThrowIfNotMatch($"Missing KeyCode.{fromKey}")
                .Set(OpCodes.Ldc_I4, (int)toKey);
        }

     

    }
}
