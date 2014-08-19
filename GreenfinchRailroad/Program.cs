using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace GreenfinchRailroad
{
    public struct City
    {
        public char name;
        public City(char c)
        {
            name = c;
        }
    }
  
    class Program
    {
        static bool isDebug = true;
        public static void print(string s)
        {
            if (isDebug) Console.WriteLine(s);
        }
        static void Main(string[] args)
        {
            //Graph object instantiated with total amount of cities (assumption: n is known)
            Graph graph = new Graph(5);
            string inputData = "AB5,BC4,CD8,DC8,DE6,AD5,CE2,EB3,AE7";
            string[] connectingCities = inputData.Split(',');
            graph.PopulateGraph(connectingCities);
            graph.PrintAdjacencyMatrix();
            DoTests(graph);
            Console.Read();
        }
        static void DoTests(Graph graph)
        {
            print("---------------------------------");
            print("Questions 1-5");
            print("---------------------------------");
            List<char[]> testRoutes=new List<char[]>();
            char[] route1 = { 'A', 'B', 'C' };
            char[] route2 = { 'A', 'D' };
            char[] route3 = { 'A', 'D', 'C' };
            char[] route4 = { 'A', 'E', 'B', 'C', 'D' };
            char[] route5 = { 'A', 'E', 'D' };
            testRoutes.Add(route1);
            testRoutes.Add(route2);
            testRoutes.Add(route3);
            testRoutes.Add(route4);
            testRoutes.Add(route5);
            int distance1 = graph.FindRouteDistance(testRoutes[0]);
            Debug.Assert(distance1 == 9, "Answer is incorrect");
            int distance2 = graph.FindRouteDistance(testRoutes[1]);
            Debug.Assert(distance2 == 5, "Answer is incorrect");
            int distance3 = graph.FindRouteDistance(testRoutes[2]);
            Debug.Assert(distance3 == 13, "Answer is incorrect");
            int distance4 = graph.FindRouteDistance(testRoutes[3]);
            Debug.Assert(distance4 == 22, "Answer is incorrect");
            int distance5 = graph.FindRouteDistance(testRoutes[4]);
            Debug.Assert(distance5 == 0, "Answer is incorrect");

            print("---------------------------------");
            print("Questions 6-7");
            print("---------------------------------");
            int count1 = graph.GetRoutesWithMaxStops('C', 'C', 3).Count;
            print("Routes from C-C with less than 3 stops = " + count1);
            Debug.Assert(count1 == 2, "Answer is incorrect");
            int count2 = graph.GetRoutesWithExactNumberOfStops('A', 'C', 4).Count;
            Debug.Assert(count2 == 3, "Answer is incorrect");
            print("Routes from A-C with exactly 4 stops = " + count2);
            print("---------------------------------");
            print("Questions 8-9");
            print("---------------------------------");
            int distance6 = graph.GetShortestRouteBetween('A', 'C').GetDistance();
            Debug.Assert(distance6 == 9, "Answer is incorrect");

            int distance7 = graph.GetShortestRouteBetween('B', 'B').GetDistance();
            Debug.Assert(distance7 == 9, "Answer is incorrect");
            print("---------------------------------");
            print("Questions 10");
            print("---------------------------------");
            int count3 = graph.GetRoutesWithDistanceLowerThan('C', 'C',30).Count;
            Debug.Assert(count3 == 7, "Answer is incorrect");

        }
    }
}
