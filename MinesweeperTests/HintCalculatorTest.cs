using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class HintCalculatorTest
    {
        [Fact]
        public void CreateHintsShould_DoNothing_WhenThereIsOnly1MineSquare()
        {
            var mineGenerator = new RandomMinesGenerator();
            var hintsCalculator = new HintCalculator();
            var board = Board.CreateEmptyBoard(1);
            mineGenerator.PlaceMines(1, board);

            hintsCalculator.SetHints(board);
            foreach (var item in board.Squares)
            {
                Assert.Equal(0,item.Hint);
            }
            
        }
    }
}