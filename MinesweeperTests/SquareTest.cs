using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class SquareTest
    {
        [Fact]
        public void ToStringShould_ReturnADotString_WhenSquareIsMineAndIsNotRevealed()
        {
            var location = new Location(1,1);
            var square = new Square(location);
            var result = square.ToString();
            Assert.Equal(".", result);
        }
    }
}