using System.Collections.Generic;

namespace Minesweeper
{
    public interface IMines
    {
        public List<Mine> CreateMines(int numbers);
        public List<Mine> MineList { get; }
    }
}