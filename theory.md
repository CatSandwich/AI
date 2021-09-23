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
