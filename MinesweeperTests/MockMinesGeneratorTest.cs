using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class MockMinesGeneratorTest
    {
        
        [Fact]
        public void PlaceMinesShould_SetSquaresOnTheTopRowToMines_WhenThereAre2MinesOnASize2Board()
        {
            var board = Board.CreateEmptyBoard(2);
            var minesGenerator = new MockMinesGenerator();
            minesGenerator.PlaceMines(2, board);
            board.RevealAllSquares();
            
            const string expectedResult = "* * \n" +
                                          "0 0 \n";
            
            Assert.Equal(expectedResult, board.ToString());
        }
        
        [Fact]
        public void PlaceMinesShould_SetSquaresOnTopLeftCornerToMines_WhenThereAre1MineOnASize2Board()
        {
            var board = Board.CreateEmptyBoard(2);
            var minesGenerator = new MockMinesGenerator();
            minesGenerator.PlaceMines(1, board);
            board.RevealAllSquares();
            
            const string expectedResult = "* 0 \n" +
                                          "0 0 \n";
            
            Assert.Equal(expectedResult, board.ToString());
        }
        
        
        [Fact]
        public void PlaceMinesShould_SetSquaresOnTheTopRowToMines_WhenThereAre4MinesOnASize4Board()
        {
            var board = Board.CreateEmptyBoard(4);
            var minesGenerator = new MockMinesGenerator();
            minesGenerator.PlaceMines(4, board);
            board.RevealAllSquares();
            
            const string expectedResult = "* * * * \n" +
                                          "0 0 0 0 \n" +
                                          "0 0 0 0 \n" +
                                          "0 0 0 0 \n";
            
            Assert.Equal(expectedResult, board.ToString());
        }
    }
}