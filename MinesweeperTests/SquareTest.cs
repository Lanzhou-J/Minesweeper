using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class SquareTest
    {
        
        [Fact]
        public void ToStringShould_ReturnADotString_WhenSquareIsNotMineAndIsNotRevealed()
        {
            var location = new Location(1,1);
            var square = new Square(location);
            var result = square.ToString();
            Assert.Equal(".", result);
        }

        [Fact]
        public void ToStringShould_ReturnADotString_WhenSquareIsMineAndIsNotRevealed()
        {
            var location = new Location(1,1);
            var square = new Square(location);
            square.SetMine();
            var result = square.ToString();
            Assert.Equal(".", result);
        }
        
        [Fact]
        public void ToStringShould_ReturnAStarString_WhenSquareIsMineAndIsRevealed()
        {
            var location = new Location(1,1);
            var square = new Square(location);
            square.SetMine();
            square.Reveal();
            var result = square.ToString();
            Assert.Equal("*", result);
        }
        
        [Fact]
        public void ToStringShould_ReturnValueString_WhenSquareIsNotMineAndIsRevealed()
        {
            var location = new Location(1,1);
            var square = new Square(location);
            square.IncrementHint();
            square.Reveal();
            var result = square.ToString();
            Assert.Equal("1", result);
        }
    }
}