Roll-a-ball

Built from the Unity Learn Roll-a-ball tutorial, then extended.

What's from the tutorial:
Player movement with Rigidbody and the Input System, follow camera, walled play area, 12 rotating collectibles, score counter, win text, and a NavMesh enemy that chases the player.

What I added
Custom look: own material colours for the player, pickups, walls and enemy.
Timer: elapsed time shown on screen while playing to add to the suspence :)
Best time: saved with PlayerPrefs and shown alongside your time on the win screen.
Enemy speed-up: every pickup collected makes the enemy faster (enemySpeedUp, in the Inspector), so the end you must be really fast to win (and it's actually hard).

Scripts
File	Role
PlayerController.cs	Movement, pickups, score, timer, best time, win/lose
CameraController.cs	Follow camera with offset
Rotator.cs	Spins the pickups
EnemyMovement.cs	NavMeshAgent chase
