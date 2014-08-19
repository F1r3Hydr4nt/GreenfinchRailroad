using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenfinchRailroad
{
    class Graph
    {
        public List<City> cities;
        public int[,] routes;//stores null if no route, or distance if a route exists
        public Graph(int n)
        {
            cities = new List<City>();
            routes = new int[n, n];
        }
        public void PopulateGraph(string[] connectingCities)
        {
            //for every city pair route string extract cities and distance ensuring no duplicate cities are added to the list
            foreach (string s in connectingCities)
            {
                char firstCity = s[0];
                char secondCity = s[1];
                int distance = int.Parse(s[2].ToString());
                int firstIndex = FindCity(firstCity);
                int secondIndex = FindCity(secondCity);
                if (firstIndex == -1)
                {
                    cities.Add(new City(firstCity));
                    firstIndex = FindCity(firstCity);
                }
                if (secondIndex == -1)
                {
                    cities.Add(new City(secondCity));
                    secondIndex = FindCity(secondCity);
                }
                AddRoute(firstIndex, secondIndex, distance);
            }
            foreach (City c in cities)
            {
                Program.print(c.name.ToString());
            }
        }
        public void PrintAdjacencyMatrix()
        {
            Console.WriteLine("Adjacency Matrix");
            int cityCount = cities.Count;
            for (int i = 0; i < cityCount; i++)
            {
                string line = "";
                for (int j = 0; j < cityCount; j++) line += routes[i, j].ToString() + " ";
                Console.WriteLine(line);
            }
        }
        //returns index of city or -1 if not found
        public int FindCity(char c)
        {
            int index = -1;
            for (int i = 0; i < cities.Count; i++)
                if (cities[i].name == c) index = i;
            return index;
        }
        //Routes are one way only
        public void AddRoute(int city1, int city2, int distance)
        {
            routes[city1, city2] = distance;
        }
        public int GetRoute(int city1, int city2)
        {
            return routes[city1, city2];
        }
        public int FindRouteDistance(char[] routeCities){
            int totalDistance = 0;
            int i = 0;
            do
            {
                int currentCity = FindCity(routeCities[i]);
                i++;
                int connectingCity = FindCity(routeCities[i]);
                int distance = GetRoute(currentCity, connectingCity);
                if (distance != 0) totalDistance += distance;
                else
                {
                    totalDistance = 0;
                    break;
                }
            } while (i < routeCities.Count()-1);
            if (totalDistance > 0) Program.print("Total distance of route " + new string(routeCities) + " = " + totalDistance);
            else Program.print("NO SUCH ROUTE between " + new string(routeCities));
            return totalDistance;
        }
    }
}
