using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenfinchRailroad
{
    public class Connection
    {
        public City start;
        public City end;
        public int distance;

        public Connection(City startCity, City endCity, int dist)
        {
            start = startCity;
            end = endCity;
            distance = dist;
        }
    }
}
