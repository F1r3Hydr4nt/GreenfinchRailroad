GreenfinchRailroad
==================

Travelling Salesman Interview Code Review

The Problem
The local commuter rail road services a number of towns in Ireland. Because of monetary concerns, all of the 
tracks are 'one-way.' That is, a route from Dublin to Galway does not imply the existence of a route from 
Galway to Dublin. In fact, even if both of these routes do happen to exist, they are distinct and are not 
necessarily the same distance!
The purpose of this problem is to help the rail road provide its customers with information about the routes. 
In particular, you will compute the distance along a certain route, the number of different routes between two
towns, and the shortest route between two towns.
Inputs
A directed graph where a node represents a town and an edge represents a route between two towns. The 
weighting of the edge represents the distance between the two towns. A given route will never appear more
than once, and for a given route, the starting and ending town will not be the same town.
Questions
For questions 1 through 5, if no such route exists, output 'NO SUCH ROUTE'. Otherwise, follow the route as 
given; do not make any extra stops! For example, the first problem means to start at city A, then travel directly 
to city B (a distance of 5), then directly to city C (a distance of 4).
Find the Distance...
1. Find the distance of the route A-B-C.
2. Find the distance of the route A-D.
3. Find the distance of the route A-D-C.
4. Find the distance of the route A-E-B-C-D.
5. Find the distance of the route A-E-D.
Find the number of trips…
6. Find the number of trips starting at C and ending at C with a maximum of 3 stops. In the sample data 
below, there are two such trips: C-D-C (2 stops) and C-E-B-C (3 stops)
7. Find the number of trips starting at A and ending at C with exactly 4 stops. In the sample data below, 
there are three such trips: A to C (via B, C and D); A to C (via D, C and D); and A to C (via D, E and B).
Find the length of the shortest route…
8. Find the length of the shortest route (in terms of distance to travel) from A to C.
9. Find the length of the shortest route (in terms of distance to travel) from B to B.
Find the number of Routes…
10. Find the number of different routes from C to C with a distance of less than 30. In the sample data, 
the trips are: CDC, CEBC, CEBCDC, CDCEBC, CDEBC, CEBCEBC and CEBCEBCEBC.3 | P a g e
Test Data
For the test input, the towns are named using the first few letters of the alphabet from A to E. A route 
between two towns (A to B) with a distance of 5 is represented as AB5.
The Input graph for the tests is: “AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7”.
Expected Output
Output #1: 9
Output #2: 5
Output #3: 13
Output #4: 22
Output #5: NO SUCH ROUTE
Output #6: 2
Output #7: 3
Output #8: 9
Output #9: 9
Output #10: 7
Notes & Guidelines
 The solution must be written in Java or C#.
 The solution should include some automated testing code.
 The final output should contain some interface to allow the user to run the program. Whether this is 
graphical or command-line based is a matter for you to decide.
 You should provide some elementary instructions to help the would-be user get up and running with 
the program.
Hints
At the heart of this problem is a graph-related algorithm commonly used for solving problems like this, extra 
points for identifying the specific algorithm that should be used. Also, there are some well-known design 
patterns that will help you in this task, so even more extra points for applying appropriate pattern or patterns. 
Finally, we value clean, well-structured, object-oriented, self-documenting code and simple well-organized 
interfaces, so please bear this in mind.
