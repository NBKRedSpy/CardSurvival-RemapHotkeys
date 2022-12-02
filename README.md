# Remap Hotkeys

## Version Note
This is for the game version 1.02.  As of 12/2/2022 1.02 is in the beta branch.
For version 1.01r (the previous version) use the Screen Hotkeys mod from one of these locations:

* https://www.nexusmods.com/cardsurvivaltropicalisland/mods/1
* https://github.com/NBKRedSpy/CardSurvivalScreenHotKeys/releases/

## Description
Allows remapping the hotkeys for the Card Survival game.

Also adds using space bar to accept most dialogs.

To remap keys, edit the config file.  See [Changing Keys](#changing-keys) below
### Game Note
The game currently adds all of the hot keys except the "Spacebar to accept dialog" hotkey.
If you do not need to customize the bindings and do not need "Spacebar to Accept", then there is no need to use this mod.

## Keys

|Key|Description|Added by Mod|
|--|--|--|
|Space|Accept action (works for most dialogs)|Yes|
|A|Scroll Location Left||
|S|Scroll Location Right||
|Q|Scrolls most card lines left||
|W|Scrolls most card lines right||
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
 
For example: The Fishing spear has two options:  Train and Break.  When pressing space bar, the Train action will be activated.

If the dialog is for a container, accepting the action will take all items out of the container.


# Changing Keys
The keys can be changed in the config file which is located at ```<Steam Directory>\steamapps\common\Card Survival Tropical Island\BepInEx\config\RemapHotkeys.cfg```.

The description and valid values for the keys are listed in the config file.

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
