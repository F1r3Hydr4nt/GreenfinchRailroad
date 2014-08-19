using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenfinchRailroad
{
    class SearchAlgorithm
    {
            private Func<Tour, bool> breakCriteria;
            private Func<Tour, bool> addCriteria;
            private Graph graph;
            private Tour trip;
            private List<Tour> possibleTrips;
            private Tour shortestTrip;
            private bool shouldBreak;
            private City endCity;
            private int shortestDistance = int.MaxValue;

            public SearchAlgorithm(Graph g,Func<Tour, bool> b,Func<Tour, bool> a,Tour t, bool br)
            {
                graph = g;
                breakCriteria = b;
                addCriteria = a;
                trip = t;
                shouldBreak = br;
                possibleTrips = new List<Tour>();
            }

            public SearchAlgorithm(Graph g, Tour t, City end)
            {
                graph = g;
                trip = t;
                endCity = end;
            }

            public List<Tour> FindRoutes()
            {
                depthFirst(trip);
                foreach (Tour t in possibleTrips)
                {
                    Program.print(t.ToString());
                }
                return possibleTrips;
            }

            public Tour FindShortest()
            {
                DijkstraAlgorithm(trip);
                Program.print(shortestTrip.ToString()+" distance:"+shortestTrip.GetDistance());
              
                return shortestTrip;
            }
            private void depthFirst(Tour trip)
            {
                if (breakCriteria(trip))
                    return;

                if (addCriteria(trip))
                {
                    possibleTrips.Add(trip);
                    if (shouldBreak)
                        return;
                }

                foreach (Connection connection in graph.GetRoutesFrom(trip.GetLastCity()))
                {
                    var t = new Tour(trip.startCity);
                    t.AddExistingRoute(trip.Route);
                    t.connections.Add(connection);
                    depthFirst(t);
                }
            }

            private void DijkstraAlgorithm(Tour trip)
            {
                if (IsShortest(trip))
                {
                    SetShortest(trip);
                    return;
                }

                foreach (Connection neighbour in graph.GetRoutesFrom(trip.GetLastCity()))
                {
                    if (VisitedAlready(trip, neighbour))
                        continue;
                    var t = new Tour(trip.startCity);
                    t.AddExistingRoute(trip.Route);
                    t.connections.Add(neighbour);
                    DijkstraAlgorithm(t);
                }
            }

            bool VisitedAlready(Tour trip, Connection neighbour)
            {
                return trip.Contains(neighbour);
            }

            private void SetShortest(Tour trip)
            {
                shortestTrip = trip;
                shortestDistance = trip.GetDistance();
            }

            private bool IsShortest(Tour trip)
            {
                if (!trip.IsEmpty() && FinishesAtCorrectCity(trip))
                    return trip.GetDistance() < shortestDistance;
                return false;
            }

            private bool FinishesAtCorrectCity(Tour trip)
            {
                return (trip.GetLastCity().Equals(endCity));
            }
        }
}
