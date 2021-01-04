using System.Linq;
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
        
        [Fact]
        public void SetHintsShould_Set3HintsWithValue1_WhenThereIs1Mine_InASize2Board()
        {
            var board = Board.CreateEmptyBoard(2);
            var mineGenerator = new RandomMinesGenerator();
            var hintsCalculator = new HintCalculator();
            mineGenerator.PlaceMines(1, board);
        
            hintsCalculator.SetHints(board);

            var squaresWithHintValueOne = board.Squares.Where(item => item.Hint == 1);
            Assert.Equal(3, squaresWithHintValueOne.Count());
        }
        
        [Fact]
        public void SetHintsShould_Set8HintsWithValue1_WhenThereIs1Mine_InTheMiddleOfASize3Board()
        {
            var board = Board.CreateEmptyBoard(3);
            var square = board.GetSquare(1, 1);
            square.SetMine();
            
            var hintsCalculator = new HintCalculator();
            hintsCalculator.SetHints(board);

            var squaresWithHintValueOne = board.Squares.Where(item => item.Hint == 1);
            Assert.Equal(8, squaresWithHintValueOne.Count());
        }
        
        [Fact]
        public void SetHintsShould_Set3HintsWithValue1_WhenThereIs1Mine_InTheTopLeftCornerOfASize3Board()
        {
            var board = Board.CreateEmptyBoard(3);
            var square = board.GetSquare(0, 0);
            square.SetMine();
            
            var hintsCalculator = new HintCalculator();
            hintsCalculator.SetHints(board);

            var squaresWithHintValueOne = board.Squares.Where(item => item.Hint == 1);
            var squaresWithHintValueZero = board.Squares.Where(item => item.Hint == 0);
            Assert.Equal(3, squaresWithHintValueOne.Count());
            Assert.Equal(6, squaresWithHintValueZero.Count());
        }
        
        [Fact]
        public void SetHintsShould_Set2HintsWithValue2_WhenThereAre2Mines_InTheTopLineOfASize2Board()
        {
            var board = Board.CreateEmptyBoard(2);
            var topLeftSquare = board.GetSquare(0, 0);
            topLeftSquare.SetMine();
            var topRightSquare = board.GetSquare(0, 1);
            topRightSquare.SetMine();

            var hintsCalculator = new HintCalculator();
            hintsCalculator.SetHints(board);

            var squaresWithHintValueTwo = board.Squares.Where(item => item.Hint == 2);
            Assert.Equal(2, squaresWithHintValueTwo.Count());
        }
    }
}