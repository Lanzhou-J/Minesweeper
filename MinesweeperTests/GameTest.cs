using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class GameTest
    {
        [Fact]
        public void SetUpShould_CreateA4by4HiddenBoard_WhenInputDifficultyLevelIs4()
        {
            var difficultyLevelInput = "4";
            var input = new MockInput(new[]{difficultyLevelInput});
            var output = new MockOutput();
            var game = new Game(input, output);
            game.SetUpBoard();
            var result = game.Board.ToString();
            const string expectedResult = ". . . . \n" + ". . . . \n" + ". . . . \n" + ". . . . \n";
            
            Assert.Equal(expectedResult, result);
        }
    }
}