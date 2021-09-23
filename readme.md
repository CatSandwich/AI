# GAME310 - PLAR Assessment

## Course Learning Outcomes (CLO)
1. Identify key factors which historically progressed artificial intelligence (AI) used in different genres of games. 
2. Create simple finite state machines to regulate game character’s options for possible actions. 
3. Implement accurate pathfinding calculations using navigational meshes to create dynamic movement of non-playable characters (NPC) within a game. 
4. Design detailed behaviour trees to control NPC’s decision making logic within a game. 
5. Use realistic flocking behaviour to create varied movement within a group while maintaining a common target within a game. 


## PLAR Enemy 1 – Spawning, Vectors, NavMesh and Pathfinding

**CLO: 1, 3, 5 (see above)**

Your project should have:
- A NavMesh Agent 
- A custom script for the enemy to handle navigation 
- A flocking manager script to manage the flock

AI Implementation:  
- This enemy should spawn from a pink spawn location and use NavMesh components to move towards the blue area
- Every 30 seconds a new enemy should spawn from the spawner for a maximum of 20 enemies
- The enemies should move towards the flocking area with the blue flooring 
- Once there, they should remain in the blue section moving around cohesively using flocking
- The flocking controller should have exposed parameters in the editor to determine how much weight, range or distance the enemies can have

## PLAR Enemy 2 – FSM, Behaviour Trees, Waypoints and Navigation

**CLO: 1,2,4 (see above)** 

Your project should demonstrate knowledge of the following: 

- Node and Edge classes 
- A custom script for the enemy to handle navigation 
- An array of waypoints 
- Finite State machine Enum 
- Behaviour Tree handling of states
- 3D Gameobjects for use as waypoint targets 
- Raycasting 

AI Implementation:  

- Create a Finite state machine for the enemy2 prefab which contains at least 3 states (Idle, Following, Attacking, etc...) 
- Create a waypoint system which directs the enemy around the map from one end of the green floored hallway to the other and back again 
  - This should continuously loop
- Add to the enemy2 an implementation of a Behavior Tree which contains the following: 
  - Sequence Nodes node(s) 
  - Selector Nodes 
  - Conditions 
- The enemy should have multiple state changes (each with a different animation or some visible change noted like a colour change on the enemy):
  - **IDLE (Green):** The enemy should begin in the idle state and walk around the waypoint path of the entire map.	 
  - **FOLLOWING (Yellow):** The enemy should change to following when the user is within a larger radius. 
  - **ATTACKING (Red):** The enemy should change to attacking when the user is within a more confined radius. 
- If the player flees both radiuses, the enemy should attempt to return to its idle state and continue on its path around the map. 
To accomplish this, the player should be able to move twice as quick as the enemy speed. 

## Submission: 

You will be expected to submit a link to a github repository with a breakdown document which indicates all files and folders which 
relate to the AI tasks above for review. You should have your name and date included in a comment in any custom scripts or functions 
written for the project. You will need to include documentation which clearly explains where previous historic pathfinding algorithms 
have led to the Implementation you have chosen for your pathfinding in this assignment to complete CLO1. 
