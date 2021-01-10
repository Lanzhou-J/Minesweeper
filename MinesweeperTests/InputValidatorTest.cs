using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class InputValidatorTest
    {
        [Fact]
        public void IsValidDifficultyInputShould_ReturnTrue_WhenInputIsAnIntegerLargerThan0()
        {
            var input = "10";
            var result = InputValidator.IsValidDifficultyInput(input);
            Assert.True(result);
        }
    }
}