using System.Collections.Generic;

namespace Minesweeper
{
    public class RandomMines : IMines
    {
        public RandomMines(int number)
        {
            MineList = CreateMines(number);
        }

        public List<Mine> CreateMines(int numbers)
        {
            throw new System.NotImplementedException();
        }

        public List<Mine> MineList { get; }
    }
}