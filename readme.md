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
- [A NavMesh Agent](https://i.imgur.com/WBPh3S5.gif)
- [A custom script for the enemy to handle navigation](https://github.com/CatSandwich/AI/blob/master/Assets/Scripts/Enemy1.cs#L32)
- [A flocking manager script to manage the flock](https://github.com/CatSandwich/AI/blob/master/Assets/Scripts/Enemy1.cs#L10)

AI Implementation:  
- This enemy should spawn from a [pink spawn location](https://github.com/CatSandwich/AI/blob/master/Assets/Scripts/EnemySpawner.cs#L17) and use NavMesh components to [move towards the blue area](https://github.com/CatSandwich/AI/blob/master/Assets/Scripts/Enemy1.cs#L34)
- [Every 30 seconds a new enemy should spawn from the spawner for a maximum of 20 enemies](https://github.com/CatSandwich/AI/blob/master/Assets/Scripts/EnemySpawner.cs#L12-L13)
- [The enemies should move towards the flocking area with the blue flooring](https://i.imgur.com/bB68lDc.png) 
- [Once there, they should remain in the blue section moving around cohesively using flocking](https://github.com/CatSandwich/AI/blob/master/Assets/Scripts/Enemy1.cs#L55-L62)
- [The flocking controller should have exposed parameters in the editor to determine how much weight, range or distance the enemies can have](https://github.com/CatSandwich/AI/blob/master/Assets/Scripts/Enemy1.cs#L10-L18)

## PLAR Enemy 2 – FSM, Behaviour Trees, Waypoints and Navigation

**CLO: 1,2,4 (see above)** 

Your project should demonstrate knowledge of the following: 

- [Node and Edge classes](https://github.com/CatSandwich/AI/tree/master/Assets/Scripts/BehaviourTree)
- [A custom script for the enemy to handle navigation](https://github.com/CatSandwich/AI/tree/master/Assets/Scripts/StateMachine)
- [An array of waypoints](https://github.com/CatSandwich/AI/blob/master/Assets/Scripts/Enemy2.cs#L21) 
- [Finite State machine Enum](https://github.com/CatSandwich/AI/blob/master/Assets/Scripts/Enemy2.cs#L81-L86) 
- [Behaviour Tree handling of states](https://github.com/CatSandwich/AI/blob/master/Assets/Scripts/Enemy2.cs#L50-L64)
- [3D Gameobjects for use as waypoint targets](https://i.imgur.com/31dXjkT.png) 
- Raycasting 

AI Implementation:  

- [Create a Finite state machine for the enemy2 prefab which contains at least 3 states (Idle, Following, Attacking, etc...)](https://github.com/CatSandwich/AI/blob/master/Assets/Scripts/Enemy2.cs#L25-L39)
- [Create a waypoint system which directs the enemy around the map from one end of the green floored hallway to the other and back again](https://github.com/CatSandwich/AI/blob/master/Assets/Scripts/StateMachine/IdleState.cs#L16-L26)
  - This should continuously loop
- Add to the enemy2 an implementation of a [Behavior Tree]((https://github.com/CatSandwich/AI/blob/master/Assets/Scripts/Enemy2.cs#L50-L64)) which contains the following: 
  - [Sequence Nodes node(s)](https://github.com/CatSandwich/AI/blob/master/Assets/Scripts/BehaviourTree/SequenceNode.cs) 
  - [Selector Nodes](https://github.com/CatSandwich/AI/blob/master/Assets/Scripts/BehaviourTree/SelectorNode.cs) 
  - [Conditions](https://github.com/CatSandwich/AI/blob/master/Assets/Scripts/BehaviourTree/ConditionNode.cs) 
- The enemy should have multiple state changes (each with a different animation or some visible change noted like a colour change on the enemy):
  - [**IDLE (Green):**](https://github.com/CatSandwich/AI/blob/master/Assets/Scripts/StateMachine/IdleState.cs) The enemy should begin in the idle state and walk around the waypoint path of the entire map.	 
  - [**FOLLOWING (Yellow):**](https://github.com/CatSandwich/AI/blob/master/Assets/Scripts/StateMachine/FollowState.cs) The enemy should change to following when the user is within a larger radius. 
  - [**ATTACKING (Red):**](https://github.com/CatSandwich/AI/blob/master/Assets/Scripts/StateMachine/AttackState.cs) The enemy should change to attacking when the user is within a more confined radius. 
- If the player flees both radiuses, the enemy should attempt to [return to its idle state](https://github.com/CatSandwich/AI/blob/master/Assets/Scripts/Enemy2.cs#L63) and continue on its path around the map. 
To accomplish this, the player should be able to move twice as quick as the enemy speed. 

## Submission: 

You will be expected to submit a link to a github repository with a breakdown document which indicates all files and folders which 
relate to the AI tasks above for review. You should have your name and date included in a comment in any custom scripts or functions 
written for the project. You will need to include [documentation which clearly explains where previous historic pathfinding algorithms 
have led to the Implementation you have chosen for your pathfinding in this assignment to complete CLO1](https://github.com/CatSandwich/AI/blob/master/theory.md). 
