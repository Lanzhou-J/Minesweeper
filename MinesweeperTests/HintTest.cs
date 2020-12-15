using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class HintTest
    {
        [Fact]
        public void ToAStringShould_ReturnADotString_WhenMineIsNotRevealed()
        {
            var location = new Location(1,1);
            var hint = new Hint(location, 1);
            var result = hint.ToAString();
            Assert.Equal(".", result);
        }
        
        [Fact]
        public void ToAStringShould_ReturnAStarString_WhenMineIsRevealed()
        {
            var location = new Location(1,1);
            var hint = new Hint(location, 1) {IsRevealed = true};
            var result = hint.ToAString();
            Assert.Equal("1", result);
        }
    }
}