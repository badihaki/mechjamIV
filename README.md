# mechjamIV
A paltform fighter made for MechJam IV. Made in Unity3D

## Todo

### Gameplay
* Player State Machine - EmbarkMech -> RidingMech -> DisembarkMech
* Player ammo management
* Mech
	* State Machine
		* Inactive
		* Idle
		* Move
		* Jump
		* Dash
		* Attacks
			* 3 hit on ground
			* 1 Air attack
* Gameplay Loop
	* Start screen
	* Character Select
	* Match
	* Match end
* Hitstop
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

### Narrative
* What is the narrative?
	* Player motivations?

## Implemented Features
### Player
* Full State Machine
	* Idle
	* Move
	* Jump
	* Falling
	* Dead
	* Dashing
* Can shoot
* Can switch weapons
### Weapons
* Weapon implement
* Weapon pickups
* Projectiles work
### Gameplay
* Player Input Manager implemented
	* players can spawn normally