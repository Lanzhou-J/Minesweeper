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

        public List<Location> FindNeighboursFromLocations()
        {
            return null;
        }
        
        public List<Location> FindNeighboursFromLocations(List<Location> locations)
        {
            var neighbours = new List<Location>();
            if (locations.Count <= 1) return null;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i==0 && j==0) continue;
                    var xValue = X + i;
                    var yValue = Y + j;
                    
                    var neighbour = locations.Find(item => item.X == xValue && item.Y == yValue);
                    if (NeighbourExistInLocations(neighbour))
                    {
                        neighbours.Add(neighbour);  
                    }
                }
            }
            return neighbours;
        }

        private static bool NeighbourExistInLocations(Location neighbour)
        {
            return neighbour != null;
        }

        public bool Equal(Location location)
        {
            return X == location.X && Y == location.Y;
        }
    }
}