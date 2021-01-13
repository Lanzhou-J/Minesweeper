using System.Linq;
using Minesweeper;

namespace MinesweeperTests
{
    public class MockMinesGenerator : IGenerateMines
    {

        public void PlaceMines(int numberOfMines, Board board)
        {
            var selectedSquares = board.Squares.Take(numberOfMines);
            foreach (var item in selectedSquares)
            {
                item.SetMine();
            }
        }
    }
}