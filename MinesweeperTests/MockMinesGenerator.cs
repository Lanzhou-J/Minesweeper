using System.Collections.Generic;
using System.Linq;
using Minesweeper;

namespace MinesweeperTests
{
    public class MockMinesGenerator : IGenerateMines
    {
        public List<Mine> CreateMines(int number, List<Location> locations)
        {
            var mines = new List<Mine>();
            var selectedLocations = locations.Take(number);
            foreach (var item in selectedLocations)
            {
                var newMine = new Mine(item);
                mines.Add(newMine);
            }
            return mines;
        }
    }
}