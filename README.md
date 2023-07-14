# mechjamIV
A paltform fighter made for MechJam IV. Made in Unity3D

## Controls
Controls will be listed as KBM || Gamepad
* Move - Arrows Keys || Left Thumb Stick
* Jump - Space || Bottom Face Buttom
* Interact - F || Right Face Button
* Attack - A || Right Trigger
* Dash - Left Shift || Left Trigger
* Start - Enter || Start Button

## How To Play
You will enter a test room with a mech (the cube) and a weapon pickup. You can press 'Start' to spawn a player. Up to two players can be spawned.

## Todo

### BUGS
* Infinite dash in air?
	* Trail and dash state fire off in the air, why?

### Gameplay
* Player Dashing (Important)
	* Instead of having multiple dashes, lean into the shmoovement of mid-air dashing.
	* Give everyone 2 stocks of dash, reset it on the ground
* Player ammo management
* Mech
	* State Machine
		* Jump
		* Dash
		* Attacks
			* 3 hit on ground
			* 1 Air attack
	* Fuel mechanic
* Gameplay Loop
	* Start screen
	* Character Select
	* Match
	* Match end
* Hitstop
* Fuel and Ammo pickups
* Tutorial
	
### Art
* Pilot animations (male/female body types)
	* Idle
	* Move
	* Air
	* Dash
* Mech Models (2)
	* Animations
		* Idle
		* Move
		* Air
		* Dash
		* Attack (3)
		* Air Attack
		* Get Hit
	* Effects
* UI
	* Dash cooldown
	* Weapon ammo
* Background Graphics
* Weapon Graphics
* Better explosion FX
	* Draw smoke graphics (3 sprites) and replace graphics
* Better blood FX
	* Blood droplets, dawg. Change the color when applying
* Create hit FX


### Sound
* Melee hit
* Projectile hit
* Pilot death
* Mech hit
* Mech explosion
* Pilot Jump
* Mech Jump

### Narrative
* What is the narrative?
	* Player motivations?

## Implemented Features

### Pilot
* Full State Machine
	* Idle
	* Move
	* Jump
	* Falling
	* Dead
	* Dashing
	* EmbarkMech
	* RidingMech
	* DisembarkMech
* Can shoot
* Can switch weapons
### Mech
* State Machine
	* Inactive
	* Idle
	* Move
### Weapons
* Weapon implement
* Weapon pickups
* Projectiles work
### Gameplay
* Player Input Manager implemented
	* players can spawn normally