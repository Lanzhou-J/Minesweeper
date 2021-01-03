using System.Collections.Generic;

namespace Minesweeper
{
    public interface IGenerateMines
    {
        public Board CreateMines(int number, Board board);

    }
}