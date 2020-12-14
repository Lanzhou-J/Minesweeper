using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class LocationTest
    {
        [Fact]
        public void GetNeighboursLocationsShould_ReturnEmptyList_WhenNoArgument()
        {
            var location = new Location(0,0);
            var result = location.GetNeighboursLocations();
            Assert.Null(result);
        }

    }
}