# Standard Assets: Character Package


## READ ME FIRST

* All project items currently under ** /Assets/_24BitDemo/**  are merely temporary assets used for prototyping and testing purposes and should be ignored.



## Overview

This repository contains the new **Standard Assets Character Controller Package**, consisting of both code to drive a more advanced version of First and Third Person Characters than the old Standard Assets Character, as well as a demo scene and setup for Character prototyping purposes and example setup of First and Third Person Characters.

For more detailed documentation, please see the WIP Google Docs:  
* Overview:

	https://docs.google.com/document/d/15bda-1wa4fn_ecUcWXTvxAZsNBIsI89zztKf2UxoQY4/edit?usp=sharing

* Quick Start Guide:

	https://docs.google.com/document/d/1DiyRG4FYeMhka8LfzXbkPFBS7oaYJo0Cg9asBbvYsDs/edit?usp=sharing

* Open Character Controller:

	https://docs.google.com/document/d/1TAodMmM8OlbFibyWvOKEU-zj-HI-yI4YJJx45S-hwTo/edit?usp=sharing	

* First Person Controller:

	https://docs.google.com/document/d/14C-a3P5o3tAXWd_Dzl8Zc-jh3uQUTaKcfWxPvqXv9w0/edit?usp=sharing

* Third Person Contoller:

	https://docs.google.com/document/d/1uU6SqWtDF0BPT81bYcVRBMZ2Li6XrKtGznItrfH8hvc/edit?usp=sharing

* Input (Legacy):

	https://docs.google.com/document/d/1mU1kQCVWu62lqSDdas9OfF2JY-AX9GVdd6d-q9XhFBU/edit?usp=sharing

* Movement Effects:

	https://docs.google.com/document/d/1544ZvaGuWcW47CViHq1lHZkiuuqwVaxz7Cd4htyea-A/edit?usp=sharing	


## Getting Started

### From Repo
* Pull the repository and open the project in the relevant version of Unity
* Open the Protoland Scene
* Press Play
* Select First or Third Person modes

### Importing the Package
* Import the SAC package.
* Copy the manifest.json into the Packages folder. (NEED TO UPLOAD AND ADD LINK)
    * This might result in packages being downloaded (internet access is required).
    
### Base Setup
* Create a new Scene.
* Place a plane in the Scene to act as the floor and resize to preference.
* Optional set-up for effects:
    * Drag in Movement Zone Manager prefab.
    * To change the level default effects, create a new LevelMovementZoneConfiguration via Create -> Standard Assets -> Characters -> Level Movement Zone Configuration and set it on this prefab
    * Set the plane’s layer to Ground, in order for Third Person footsteps to work.
    
### First Person Setup
* Drag in the First Person prefab.

### Third Person Setup
* Drag in the Third Person (Male) prefab.
    * Ensure that the Y value is greater than the Ground Plane’s Y value.
* Drag in the Third Person Camera (Male) prefab.

There is a female third person character. Delete the male prefabs from the scene and drag in the female prefabs:
* Third Person (Female)
* Third Person Camera (Female)

## Controls

* First Person
	* Keyboard + Mouse
		* Movement:		WASD / Arrow Keys
		* Look:			Mouse Cursor
		* Sprint:		Left Shift [HOLD]
		* Jump:			Spacebar
		* Crouch:		Left Ctrl [HOLD]
	* Gamepad
		* Movement:		Left Thumbstick
		* Look:			Right Thumbstick
		* Sprint:		Left Thumbstick Click [TOGGLE]
		* Jump:			PS4 [X]  Xbox [A]
		* Crouch:		Right Thumbstick Click [TOGGLE]
* Third Person
	* Keyboard + Mouse
		* Movement:		WASD / Arrow Keys
		* Camera:		Mouse Cursor
		* Sprint:		Left Shift [HOLD]
		* Jump:			Spacebar
		* Strafe:		F Key [TOGGLE]
		* Recenter:		V Key
	* Gamepad
		* Movement:		Left Thumbstick
		* Camera:		Right Thumbstick
		* Sprint:		Left Thumbstick Click [TOGGLE]
		* Jump:			PS4 [X]  Xbox [A]
		* Strafe:		Left Bumper [TOGGLE]
		* Recenter:		Right Thumstick Click



## Notable Content

	/Assets/_24BitDemo/
	
* Contains test / throwaway assets for use during the development phase of the project

#

	/Assets/_Standard Assets/Characters/
	
* Contains all code, models, and animation assets and related items for the logic of the First and Third Person Character Controllers
	* NOTE: The Input Manager setup for the Character Controllers is dependent on the mappings set up on ** InputManager.asset **

#

	/Assets/_Standard Assets/Prototyping/
	
* Contains the assets for the Pro Builder protoyping environment built to demonstrate the Character Controllers in

#

	/Assets/_Standard Assets/Characters/Exmpales/SimpleMovementController
	
* Contains an example scene and demonstration scripts for setting up a simple custom Third Person Movement Controller using both the Default Unity Character Controller as well as the new C# Open Character Controller

#

	/Assets/_Standard Assets/Characters/Exmpales/SimpleNavMeshInputController
	
* Contains an example scene and and script setup to demonstrate a simple point-and-click-to-move a character whose input is controlled by NavMesh navigation

#



## Scenes

	/Assets/_Standard Assets/Prototyping/Scenes/Protoland

* Main prototyping and demo scene for the Character Controller project

#

	/Assets/_Standard Assets/Characters/Exmpales/SimpleMovementController/Scenes/SimpleMovementController

* Example scene to demonstrate a simple custom character controller using both the Default Unity Character Controller as well as the new C# Open Character Controller

#

	/Assets/_Standard Assets/Characters/Exmpales/SimpleMovementController/Scenes/SimpleNavMeshInputController

* Example scene to demonstrate a simple NavMesh input driven character controller



## Character Controller Setup Instructions

### See the above Quick Start Guide


## Camera Setup Overview

	1) It is all located in the Protoland scene under:
		* Characters -> ThirdPerson -> Third Person Cameras
	2) There are 2 State Driven Camera camera setups:
		* Forward-Unlocked Transposing, called *Exploration* for ESL understanding
			* This has Freelook Cameras set up for Idle, Run, and Sprint states
		* Forward-Locked Rectilinear, called *Strafe* for ESL understanding
			* This only has a single Freelook Camera set up for the Strafe state
	3) A simple *Third Person Camera Animation Manager* component exists on the *Third Person Cameras* GameObject.  
		* It is designd to control how the cameras recieve input as well as for tracking all of the various cameras in the scene that the character controller can use (as well as the starting one), with the idea that this can also help handle any potential additional logic with the transitions between the cameras.
	4) A quick overview of the properties on this Camera Manager is as follows:
		* Starting Camera Mode:  Use this change whether you start is free look or strafe
		* Camera Mode Input:  Will be used to change from Free Look to Strafe and vice versa, at run-time
		* Camera Toggle Input:  Used to switch between cameras in a specific mode (Strafe: strafe to aim)
		* Free Look Camera Objects:  GameObjects that are enabled when switching to Free Look mode. e.g. custom UI
		* Strafe Camera Objects:  GameObjects that are enabled when switching to Strafe mode. e.g. crosshair
		* Free Look Camera States:  States on the animator for the different Free Look Camera modes.
		* Strafe Camera States:  States on the animator for the different Strafe Camera modes (e.g. rectilinear aiming, orbiting target)



## Project Status Overview: Phase 1

### Ready for Review and Feedback:
	* Input Manager (Legacy)
		** Code and Design Structure
		** Keyboard & Mouse, Gamepad (PS4, Xbox360, XboxOne), Mobile Touch Screen Support
		** Inspector UX Review
		** Code Review and Commenting
	
	* Open Character Controller
		** Code and Design Structure
		** Behaviour and Functionality
		** Inspector UX Review
		** Code Review and Commenting

	* First Person Controller
		** Code and Design Structure
		** Behaviour and Functionality for Walk, Sprint, Crouch, Jump
		** Inspector UX Review
		** Code Review and Commenting

	* Third Person Controller 
		** Code and Design Structure
		** Behaviour and Functionality for Idle, Walk, Run, Sprint, Turning Locomotion
		** Behaviour and Functionality for Falling and Landing
		** Standing and Running Jump Animations
		** Standing-Forward Jump Behaviour
		** Jump-Motion Curve
		** Nav Mesh Input Controller
		** Animation State Machine
		** Collision Capsule Resizing Based on Animation Frames (only set on the Landing Roll animation currently)
		** Inspector UX Review
		** Code Review and Commenting

	* Simple Movement Controller Example
		** Demo scene to test out Legacy Character Controller and Open Character Controller controlled Cylinders

	* Simple NavMesh Input Controller Example
		** Demo scene to show NavMesh driven Character Controller Input

	* Project Hygene
	    ** First Pass Documentation of the Systems and Behaviours
	    ** General Internal Code Commenting Review Pass


### Currently Being Worked On:

	* Third Person Controller 
		** Effects Detection System for Character Feet
		** Strafing Locomotion Behaviour & Blends
		** New Strafing Animations
		** Strafing Camera / Transitions
	
	* Garbage Generation and Optimation Pass


### Still Requires Work:

	* Addition of Female Avatar & Animation Set

