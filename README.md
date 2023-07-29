# Unity Sprite Afterimage Effect

This project provides a Unity script that creates an afterimage effect for sprites. When a sprite moves around the scene, it automatically leaves behind semi-transparent afterimages along its path. These afterimages will disappear after a period of time.

## How to Use

Add the AfterImageEffectController script to the sprite object you want to create the afterimage effect for, and then set the related parameters in the Unity editor.

## Parameter Settings

afterImageMaterial: In the Unity editor, you need to assign the created afterimage Shader to this Material.
fadeDuration: The disappearance time of the afterimage, in seconds.
fixedAfterImageDelay: The time interval for creating afterimages, in seconds.
enable: Control whether to enable the afterimage effect. Set to true to enable the afterimage effect.

## Operating Principle

When the global position of the sprite changes, that is, the sprite moves, the script will create a new afterimage at regular intervals.
The new afterimage object will be assigned the current sprite's image, material, color as well as position, rotation, and size information.
The script will also handle the fade out and destruction of all afterimages in each frame.

## Copyright Information

This project uses the MIT open source license. Everyone is welcome to improve and use the project.
