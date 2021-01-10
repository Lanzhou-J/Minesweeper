using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class InputValidatorTest
    {
        [Theory]
        [InlineData("10")]
        [InlineData("1")]
        public void IsValidDifficultyInputShould_ReturnTrue_WhenInputIsAnIntegerLargerThan0(string input)
        {
            var result = InputValidator.IsValidDifficultyInput(input);
            Assert.True(result);
        }

        [Theory]
        [InlineData("0")]
        [InlineData("-1")]
        [InlineData("-100")]
        public void IsValidDifficultyInputShould_ReturnFalse_WhenInputIsAnIntegerLessOrEqualTo0(string input)
        {
            var result = InputValidator.IsValidDifficultyInput(input);
            Assert.False(result);
        }
        
        [Theory]
        [InlineData("Lan")]
        [InlineData("0,0")]
        [InlineData("00,0")]
        [InlineData("1.2")]
        public void IsValidDifficultyInputShould_ReturnFalse_WhenInputIsNotAnInteger(string input)
        {
            var result = InputValidator.IsValidDifficultyInput(input);
            Assert.False(result);
        }

        [Fact]
        public void IsValidLocationInputShould_ReturnTrue_WhenInputIsInCorrectFormatAndWithinBoardScope()
        {
            var input = "0,0";
            var result = InputValidator.IsValidLocationInput(input, 4);
            Assert.True(result);
        }
    }
}