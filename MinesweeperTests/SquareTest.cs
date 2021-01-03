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
        
        [Fact]
        public void ToStringShould_ReturnAStarString_WhenIsMineAndIsRevealed()
        {
            var location = new Location(1,1);
            var square = new Square(location);
            square.Reveal();
            var result = square.ToString();
            Assert.Equal("*", result);
        }
    }
}