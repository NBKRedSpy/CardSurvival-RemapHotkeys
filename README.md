# Remap Hotkeys
## Demo
A demo video is available [here](https://youtu.be/VDb_FSaII50).
## Description

Adds:
* Spacebar will activate the left most button in dialogs.
    * Puddles default to "Dig up Mud"
* Allows remapping the hotkeys for the Card Survival game.
* Spacebar will accept most dialgs
* Option to prevent the game menu from opening when pressing the Close Dialog button.

To remap keys, edit the config file.  See [Changing Keys](#changing-keys) below

### Game Note
Except for the "Spacebar accepts action" hotkey, Card Survival already has the hotkeys listed in the Keys section below.  
This mod is not needed to access those hotkeys with their default bindings.

## Options
|Name|Default|Description|
|--|--|--|
|DisableMenuOnExitKey|false|If true, will prevent the close hotkey from opening the menu button.|

## Keys

|Key|Description|Added by Mod|
|--|--|--|
|Space|Accept action (works for most dialogs)|Yes|
|Q|Scroll Location Left||
|W|Scroll Location Right||
|A|Scrolls most card lines left||
|S|Scrolls most card lines right||
|E|Opens Character Equipment screen||
|C|Opens Character screen||
|H|Opens Character Health Screen||
|B|Opens Blueprint screen||
|C|Close dialog||
|T|Opens Waiting (rest/sleep) screen||
|J|Opens Journal screen||
|S|Opens Stats screen||

# Accepting Actions
If there is more than one button on a dialog, the left most button will be activated.
 
For example: The Fishing spear has two options:  Train and Break.  When pressing spacebar, the Train action will be activated.

If the Card has a "Dig up Mud" option, it will be used instead of the left most action.  Usually the left most action is Drink in these cases.)


# Changing the Configuration
All options are contained in the config file which is located at ```<Steam Directory>\steamapps\common\Card Survival Tropical Island\BepInEx\config\RemapHotkeys.cfg```.

The .cfg file will not exist until the mod is installed and then the game is run.

To reset the config, delete the config file.  A new config will be created the next time the game is run.

# Installation 
This mod requires the BepInEx mod loader.

## BepInEx Setup
If BepInEx has already been installed, skip this section.

Download BepInEx from https://github.com/BepInEx/BepInEx/releases/download/v5.4.21/BepInEx_x64_5.4.21.0.zip

* Extract the contents of the BepInEx zip file into the game's directory:
```<Steam Directory>\steamapps\common\Card Survival Tropical Island```

    __Important__:  The .zip file *must* be extracted to the root folder of the game.  If BepInEx was extracted correctly, the following directory will exist: ```<Steam Directory>\steamapps\common\Card Survival Tropical Island\BepInEx```.  This is a common install issue.

* Run the game.  Once the main menu is shown, exit the game.
    
* In the BepInEx folder, there will now be a "plugins" directory.

## Mod Setup
* Download the RemapHotkeys.zip.  
    * If on Nexumods.com, download from the Files tab.
    * Otherwise, download from https://github.com/NBKRedSpy/CardSurvival-RemapHotkeys/releases/

* Extract the contents of the zip file into the ```BepInEx/plugins``` folder.

* Run the Game.  The mod will now be enabled.

# Uninstalling

## Uninstall
This resets the game to an unmodded state.

Delete the BepInEx folder from the game's directory
```<Steam Directory>\steamapps\common\Card Survival Tropical Island\BepInEx```

## Uninstalling This Mod Only

This method removes this mod, but keeps the BepInEx mod loader and any other mods.

Delete the ```RemapHotkeys.dll``` from the ```<Steam Directory>\steamapps\common\Card Survival Tropical Island\BepInEx\plugins``` directory.
# Compatibility
Safe to add and remove from existing saves.

The UnityExplorer mod interferes with the hotkey handling when the UI is visible.

# Acknowledgments
Electric keyboard icon created by yoyonpujiono https://www.flaticon.com/free-icons/electric-keyboard
<a href="https://www.flaticon.com/free-icons/tap" title="tap icons">Tap icons created by Pixel perfect - Flaticon</a>

# Change Log
## 1.2.0
* Change: Dialogs with "Dig up Mud" will be used as the default action.
    * Should be compatible with alternate languages.

## 1.1.3
* Fix: Corrects the accept action fro "Inspection Window" executing when a "sub popup" is overlaying the buttons.  For example:  Trashing spoiled food.  Would eat instead of confirming the throw away option that is a "sub popup".  (Sorry for the diarrhea!)

## 1.1.2
* Fix:  Help screen closing if Exit Screen hotkey is not escape.
Changed code to ignore the Exit Screen hotkey if the key is not escape.
The user will need to close the screen with the X button.
* Fix:  Inspection popups could be invoked when disabled.

## 1.1.1
* Accept Action - Added Research Completed

## 1.1
* Added accept action to Blueprint Construction's Auto Fill.
* Fixed support for Inspection popups.  Now handles all types of encounters.  For example, retreating.
* Added option DisableMenuOnExitKey




