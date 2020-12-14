using System.Collections.Generic;
using System.Globalization;

namespace Minesweeper
{
    public class Mines : IMines
    {
        public List<Mine> CreateMines(int numbers)
        {
            throw new System.NotImplementedException();
        }

        public List<Mine> MineList { get; }

        public Mines( int numbers)
        {
            MineList = CreateMines(numbers);
        }
    }
}