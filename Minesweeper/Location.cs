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

        public bool Equals(Location newLocation)
        {
            return (X == newLocation.X && Y == newLocation.Y);
        }
    }
}