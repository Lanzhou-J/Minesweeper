using System.Collections.Generic;

namespace Minesweeper
{
    public interface IMines
    {
        public List<Mine> CreateMines(int number, List<Location> locations);
        public List<Mine> MineList { get; }
    }
}