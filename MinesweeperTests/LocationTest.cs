using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class LocationTest
    {
        [Fact]
        public void EqualsShould_ReturnTrue_WhenTwoLocationXAndYValueMatches()
        {
            var location = new Location(0,0);
            var newLocation = new Location(0,0);
            Assert.True(location.Equals(newLocation));
        }
    }
}