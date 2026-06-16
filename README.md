# 2D Physics-Based Slingshot Game (Angry Birds Clone)

This is a 2D physics-based game inspired by *Angry Birds*. I built this project in Unity to learn more about game physics, object interactions, and game flow using C#.

## 🛠️ What I Built

The game is divided into three main scripts, each with its own job.

### Bird Controller (`BirdScript.cs`)

This script handles the slingshot mechanic.

* Lets the player drag the bird before launching it.
* Limits how far the bird can be pulled back.
* Launches the bird using Unity's 2D physics system.
* Uses a coroutine to smoothly switch the bird from being dragged to flying through the air.
* Enables the trail effect after the bird is released.

### Enemy Controller (`EnemyScript.cs`)

This script controls how enemies react when they are hit.

* Detects collisions between the bird and enemies.
* Checks how strong the collision is.
* Destroys the enemy if the impact is strong enough.
* Tells the Game Manager when an enemy has been defeated.

### Game Manager (`GameManager.cs`)

This script manages the overall gameplay.

* Counts how many birds and enemies are left.
* Checks if the player wins or loses.
* Shows the Game Over or Victory screen.
* Handles restarting the level or moving to the next one.

## 📋 Tools & Features

* Built with **Unity** and **C#**
* Uses **Rigidbody2D**, **SpringJoint2D**, and colliders for physics
* Gameplay settings like drag distance and collision strength can be adjusted directly in the Unity Inspector without changing the code
