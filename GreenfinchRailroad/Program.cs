using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenfinchRailroad
{
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
            Console.Read();
        }
    }

    struct City
    {
        public char name;
        public City(char c)
        {
            name = c;
        }
    }

  
}
