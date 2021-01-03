using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class HintCalculatorTest
    {
        [Fact]
        public void SetHintsShould_setHintTo0_WhenThereIsOnly1MineSquare()
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
        
        [Fact]
        public void SetHintsShould_setHintTo0_WhenThereIs1Square()
        {
            var mineGenerator = new RandomMinesGenerator();
            var hintsCalculator = new HintCalculator();
            var board = Board.CreateEmptyBoard(1);
            mineGenerator.PlaceMines(0, board);
        
            hintsCalculator.SetHints(board);
            foreach (var item in board.Squares)
            {
                Assert.Equal(0,item.Hint);
            }
        }
        
        [Fact]
        public void SetHintsShould_setHintsTo0_WhenThereIsNoMine_InASize2Board()
        {
            var mineGenerator = new RandomMinesGenerator();
            var hintsCalculator = new HintCalculator();
            var board = Board.CreateEmptyBoard(2);
            mineGenerator.PlaceMines(0, board);
            hintsCalculator.SetHints(board);
            
            foreach (var item in board.Squares)
            {
                Assert.Equal(0, item.Hint);
            }
        }
    }
}