using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class MineTest
    {
        [Fact]
        public void ToAStringShould_ReturnADotString_WhenMineIsNotRevealed()
        {
            var location = new Location(1,1);
            var mine = new Mine(location);
            var result = mine.ToAString();
            Assert.Equal(".", result);
        }
        
        [Fact]
        public void ToAStringShould_ReturnAStarString_WhenMineIsRevealed()
        {
            var location = new Location(1,1);
            var mine = new Mine(location);
            mine.IsRevealed = true;
            var result = mine.ToAString();
            Assert.Equal("*", result);
        }
    }
}