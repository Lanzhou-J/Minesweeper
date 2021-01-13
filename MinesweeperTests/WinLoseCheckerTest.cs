using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class WinLoseCheckerTest
    {
        [Fact]
        public void IsWinningConditionShould_ReturnTrue_WhenAllHintsOnBoardAreRevealed()
        {
            var board = Board.CreateEmptyBoard(2);
            var mineGenerator = new MockMinesGenerator();
            mineGenerator.PlaceMines(2, board);
            var bottomLeft = new Location(1,0);
            var bottomRight = new Location(1,1);
            var hintOne = board.GetSquare(bottomLeft);
            var hintTwo = board.GetSquare(bottomRight);
            hintOne.Reveal();
            hintTwo.Reveal();
            var result = WinLoseChecker.IsWinningCondition(board);
            Assert.True(result);
        }
        
        [Fact]
        public void IsWinningConditionShould_ReturnFalse_WhenOneHintsOnBoardIsRevealed()
        {
            var board = Board.CreateEmptyBoard(2);
            var mineGenerator = new MockMinesGenerator();
            mineGenerator.PlaceMines(2, board);
            var bottomLeft = new Location(1,0);
            var hintOne = board.GetSquare(bottomLeft);
            hintOne.Reveal();
            var result = WinLoseChecker.IsWinningCondition(board);
            Assert.False(result);
        }
        
        [Fact]
        public void IsLosingConditionShould_ReturnTrue_WhenOneMineOnBoardAreRevealed()
        {
            var board = Board.CreateEmptyBoard(2);
            var mineGenerator = new MockMinesGenerator();
            mineGenerator.PlaceMines(2, board);
            var topLeft = new Location(0,0);
            var mineOne = board.GetSquare(topLeft);
            mineOne.Reveal();
            var result = WinLoseChecker.IsLosingCondition(board);
            Assert.True(result);
        }
        
        [Fact]
        public void IsLosingConditionShould_ReturnFalse_WhenNoMineOnBoardIsRevealed()
        {
            var board = Board.CreateEmptyBoard(2);
            var mineGenerator = new MockMinesGenerator();
            mineGenerator.PlaceMines(2, board);
            var result = WinLoseChecker.IsLosingCondition(board);
            Assert.False(result);
        }
    }
}