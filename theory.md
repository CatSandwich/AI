# History of Pathfinding in Video Games

Pathfinding when broken down is just finding the best route from point A to point B. In order for an object to know what space is traversible, and to allow for programmatic pathfinding, game scenes are often broken down into graphs - a set of nodes and edges that contain information about what leads where and how expensive it is to do so. Once this graph is set up, it takes algorithms to search the graph to determine the best route from point A to point B. Below are some of the common implementations.

## Breadth-First Search
A breadth-first search maps out an entire graph from the starting position, marking the difficulty from the start. It then backtracks from the goal to the object.
Steps:
1. Start from object's position
2. Count nodes outwards until all nodes are given a difficulty to reach from the start
3. Backtrack from the end now that all paths have been explored

\+ Always finds the best path\
\- Examines more than necessary; slow

## Depth-First Search
A depth-first search tries an adjacent node from the start until it reaches a dead end, at which point it backtracks and repeats the process, mapping out all possibilities.
Steps:
1. Start from object's position
2. Try a path along adjacent nodes until there are no more adjacent nodes
3. Backtrack until the last option with other adjacent nodes to try
4. Repeat on new path until all options have been mapped

\+ Always finds the best path\
\- Examines more than necessary; slow

## A* Search
In A* algorithms, the program keeps track of visited and unvisited nodes. Each node is eventually assigned a heuristic value, 
a value that declares the difficulty to reach the destination from that node. Each node also stores a value determining the difficulty to access it from other nodes.
Nodes also keep track of their parent: the node they are initially reached from. 

The algorithm then repeats from the node with the lowest difficulty + heuristic values. With other algorithm magic and swapping values around, A* comes out much more efficient than previous algorithms while maintaining the end result of finding the best path.

The algorithm is a bit too complex to reduce to steps, but here's an incredible page with more information: https://www.raywenderlich.com/3016-introduction-to-a-pathfinding

## My Choice
In this project, I chose A* for two major reasons:
- It's built into Unity using the NavMesh system, so I needed only build the graph (bake a NavMesh), then set the destination
- It's one of the best, if not the best pathfinding algorithm used in games; no reason not to use the built-in functionality

## Concepts

### Node and Edge Classes
As I was using Unity's built-in navigation, I didn't need any custom implementation of graphs, so I will explain the concept instead.

Node - A node is a point on a graph\
Edge - An edge is a connection between two nodes

These two concepts can build an entire graph, allowing for navigation along the graph. Depending on what the implementation is for, you may need different data in each class, such as difficulty to get between two nodes, or a difficulty value on the connecting edge. This would change navigation, as the goal is to find the least difficult path.

Depending on the implentation, nodes may know about their connecting edges, or edges might store information about which nodes they connect. Either way, navigation will use the information in these classes to determine which edges and nodes to travel through to get from point A to point B.

### Raycasting
I had at some point implemented raycasting in the project to make Enemy1 avoid the walls while flocking. I opted to replace that system with a smaller mesh that if left, would instruct them to turn back towards the middle of the area.

Anyway. In terms of theory, raycasting is when you send out (cast) a line (ray) in a direction to see what it hits. It is very versatile and is used in many contexts. In AI, it is often used to give "sight." In the context of this project, I had the flocking enemies look 2 units in front of them in 45 degree angles each way (a cone). This would not only tell the enemy when it was about to hit a wall, but also instruct it which way to turn based on which ray hit the wall (if the 45 degree right ray hit the wall, turn left and vice-versa). 

The reason I dropped this implementation was because once the enemy turned just slightly, the raycast would no longer hit the wall, making them go straight into it again, repeating the process until it eventually walked along the wall. While this could have been fixed by simply making the enemy turn fully backwards or some similar design choice, I opted to make a valid area for them to stay within where they would turn around upon leaving it. This gives the illusion of sight all the same by keeping them a distance away from walls.
