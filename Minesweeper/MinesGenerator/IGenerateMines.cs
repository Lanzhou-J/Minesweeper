using System.Collections.Generic;

namespace Minesweeper
{
    public interface IGenerateMines
    {
        public List<Mine> CreateMines(int number, List<Location> locations);
        
    }
}