
using System.Collections.Generic;
using System.Linq;
using Minesweeper;

namespace MinesweeperTests
{
    public class MockMinesGenerator : IGenerateMines
    {

        public void PlaceMines(int number, Board board)
        {
            var selectedSquares = board.Squares.Take(number);
            foreach (var item in selectedSquares)
            {
                item.SetMine();
            }
        }
    }
}