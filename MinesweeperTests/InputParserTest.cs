using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class InputParserTest
    {
        [Theory]
        [InlineData(1,1, "1,1")]
        [InlineData(2,1, "2,1")]
        [InlineData(5,5, "5,5")]
        public void CreateLocationBasedOnInputShould_ReturnLocationWithCorrectPropertyValue_BasedOnInput(int xValue, int yValue, string input)
        {
            var inputParser = new InputParser();
            var result = inputParser.CreateLocationBasedOnInput(input);
            Assert.Equal(xValue, result.X);
            Assert.Equal(yValue, result.Y);
        }
    }
}