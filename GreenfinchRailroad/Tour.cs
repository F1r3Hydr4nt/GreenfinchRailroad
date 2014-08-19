using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenfinchRailroad
{
        public class Tour
        {
            public City startCity;
            public List<Connection> connections;

            public List<Connection> Route
            {
                get { return connections; }
            }

            public Tour(City start)
            {
                startCity = start;
                connections = new List<Connection>();
            }

            public int GetStops()
            {
                if (connections.Any())
                    return connections.Count;
                return 0;
            }

            public City GetLastCity()
            {
                if (!IsEmpty())
                    return connections.Last().end;
                return startCity;
            }

            public bool IsEmpty()
            {
                return !connections.Any();
            }

            public int GetDistance()
            {
                var distance = 0;
                foreach (var connection in Route)
                {
                    distance += connection.distance;
                }
                return distance;
            }

            public bool Contains(Connection connection)
            {
                return connections.Any(x => x.start.name == connection.start.name && x.end.name == connection.end.name);
            }

            public void AddExistingRoute(List<Connection> connects)
            {
                foreach (Connection c in connects)
                {
                    connections.Add(c);
                }
            }

            public override string ToString()
            {
                StringBuilder result = new StringBuilder();
                for (int i = 0; i <= Route.Count - 1; i++)
                {
                    if (i == Route.Count - 1)
                        result.Append(String.Concat(Route[i].start.name, "", Route[i].end.name));
                    else
                        result.Append(String.Concat(Route[i].start.name, ""));
                }

                return result.ToString();
            }
        }
  
}
