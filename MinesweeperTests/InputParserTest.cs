using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class InputParserTest
    {
        [Theory]
        [InlineData(1,1, "1,1")]
        public void CreateLocationBasedOnInputShould_ReturnLocationWithCorrectPropertyValue_BasedOnInput(int xValue, int yValue, string input)
        {
            var inputParser = new InputParser();
            var result = inputParser.CreateLocationBasedOnInput(input);
        }
    }
}