using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class Location
    {
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public  int X {get; private set; }
        public  int Y {get; private set; }

        public List<Location> GetNeighboursLocations()
        {
            return null;
        }
        
        public List<Location> GetNeighboursLocations(List<Location> locations)
        {
            var neighboursLocation = new List<Location>();
            if (locations.Count <= 1) return null;
            neighboursLocation.AddRange(locations.Where(item => item.X != X || item.Y != Y));

            return neighboursLocation;
        }
    }
}