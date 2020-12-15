using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class RandomMinesGenerator : IGenerateMines
    {
        
        private readonly Random _random = new Random();

        public List<Mine> CreateMines(int number, List<Location> locations)
        {
            var mines = new List<Mine>();
            var selectedLocations = locations.OrderBy(x => _random.Next()).Take(number);
            foreach (var item in selectedLocations)
            {
                var newMine = new Mine(item);
                mines.Add(newMine);
            }
            return mines;
        }
        
    }
}