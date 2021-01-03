using System.Collections.Generic;

namespace Minesweeper
{
    public interface IGenerateMines
    {
        public void CreateMines(int number, Board board);

    }
}