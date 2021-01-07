using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class RuleTest
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
            var result = Rule.IsWinningCondition(board);
            Assert.True(result);
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
            var result = Rule.IsLosingCondition(board);
            Assert.True(result);
        }
    }
}