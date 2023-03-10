using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Configuration;
using DG.Tweening;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UIElements;

namespace RemapHotkeys
{
    [HarmonyPatch(typeof(GraphicsManager), "Hotkeys")]
    public static class StartEnd_GraphicsManager_Hotkeys_Patch
    {
        public static LastRepeatTimer<KeyboardShortcut> KeyRepeatCheck = new();

        public static void Prefix(GraphicsManager __instance, ref bool __runOriginal)
        {

            __runOriginal = false;

            if (GraphicsManager.PlayerIsTyping)
            {
                return;
            }

            if (StartEndKeys(__instance)) return;
            if(ScrollNextKeys(__instance)) return;

            __runOriginal = true;
        }

        private static void MoveScoll(CardLine cardLine, bool toEnd)
        {
            cardLine.MoveToPos(toEnd ? 1f : 0f, .1f, Ease.InOutSine, null);
        }


        /// <summary>
        /// Returns true if the scroll functionality should be invoked.
        /// Handles logic for key tap and scroll repeat with key hold.
        /// </summary>
        /// <param name="shortcut"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Method Declaration", "Harmony003:Harmony non-ref patch parameters modified", Justification = "<Pending>")]
        private static bool KeyActivatedCheck(KeyboardShortcut shortcut)
        {

            bool keyIsDown = shortcut.IsDown();
            bool repeatScrollEnabled = Plugin.EnableScrollRepeat.Value;

            if (keyIsDown)
            {
                if(repeatScrollEnabled) KeyRepeatCheck.Reset(shortcut);
                return true;
            }
            else
            {
                if (repeatScrollEnabled)
                {
                    if(shortcut.IsPressed())
                    {
                        return KeyRepeatCheck.IsRepeat(shortcut);
                    }

                    return false;
                }
                return false;
            }
        }

        private static bool ScrollNextKeys(GraphicsManager graphicsManager)
        {
            if (KeyActivatedCheck(Plugin.KeySettings.LocationScrollLeftKey.Value))
            {

                graphicsManager.LocationSlotsLine.MoveToPrevPos();
                return true;
            }
            else if (KeyActivatedCheck(Plugin.KeySettings.LocationScrollRightKey.Value))
            {
                graphicsManager.LocationSlotsLine.MoveToNextPos();
                return true;
            }
            else if (KeyActivatedCheck(Plugin.KeySettings.ScrollLeftKey.Value))
            {
                if ((bool)graphicsManager.CurrentInspectionPopup)
                {
                    graphicsManager.InventoryInspectionPopup.InventorySlotsLine.MoveToPrevPos();
                }
                else
                {
                    graphicsManager.BaseSlotsLine.MoveToPrevPos();
                }
                return true;
            }
            else if (KeyActivatedCheck(Plugin.KeySettings.ScrollRightKey.Value))
            {
                if ((bool)graphicsManager.CurrentInspectionPopup)
                {
                    graphicsManager.InventoryInspectionPopup.InventorySlotsLine.MoveToNextPos();
                }
                else
                {
                    graphicsManager.BaseSlotsLine.MoveToNextPos();
                }
                return true;
            }

            return false;
        }



        private static bool StartEndKeys(GraphicsManager graphicsManager)
        {
            if (Plugin.KeySettings.LocationScrollStart.Value.IsDown())
            {
                MoveScoll(graphicsManager.LocationSlotsLine, false);
                return true;
            }
            else if (Plugin.KeySettings.LocationScrollEnd.Value.IsDown())
            {
                MoveScoll(graphicsManager.LocationSlotsLine, true);
                return true;
            }
            else if (Plugin.KeySettings.ScrollStartKey.Value.IsDown())
            {
                if ((bool)graphicsManager.CurrentInspectionPopup)
                {
                    MoveScoll(graphicsManager.InventoryInspectionPopup.InventorySlotsLine, false);
                }
                else
                {
                    MoveScoll(graphicsManager.BaseSlotsLine, false);
                }
                return true;
            }
            else if (Plugin.KeySettings.ScrollEndKey.Value.IsDown())
            {
                if ((bool)graphicsManager.CurrentInspectionPopup)
                {
                    MoveScoll(graphicsManager.InventoryInspectionPopup.InventorySlotsLine, true);
                }
                else
                {
                    MoveScoll(graphicsManager.BaseSlotsLine, true);
                }
                return true;
            }

            return false;
        }
    }
}
