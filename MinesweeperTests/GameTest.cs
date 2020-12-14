using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class GameTest
    {
        [Fact]
        public void StartShould_SetAnEmptyBoardWith4RowsAnd4Columns_WhenInputDifficultyLevelIs4()
        {
            var difficultyLevelInput = "4";
            var input = new MockInput(new[]{difficultyLevelInput});
            var output = new MockOutput();
            var game = new Game(input, output);
            game.Start();
            var squareList = game.Board.ToSquareList();
            var mines = squareList.FindAll(x => x.IsMine);
            Assert.Equal(4, mines.Count);
        
        }
    }
}