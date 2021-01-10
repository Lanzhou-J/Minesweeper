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

        [Theory]
        [InlineData("0,0")]
        [InlineData("3,3")]
        [InlineData("1,1")]
        public void IsValidLocationInputShould_ReturnTrue_WhenInputIsInCorrectFormatAndWithinBoardScope(string input)
        {
            var result = InputValidator.IsValidLocationInput(input);
            Assert.True(result);
        }
        
        [Theory]
        [InlineData("0")]
        [InlineData("5.5")]
        [InlineData("7&28")]
        public void IsValidLocationInputShould_ReturnFalse_WhenInputFormatIsWrong(string input)
        {
            var result = InputValidator.IsValidLocationInput(input);
            Assert.False(result);
        }
    }
}