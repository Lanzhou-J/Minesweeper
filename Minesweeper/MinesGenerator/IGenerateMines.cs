using System.Collections.Generic;

namespace Minesweeper
{
    public interface IGenerateMines
    {
        public void PlaceMines(int number, Board board);

    }
}