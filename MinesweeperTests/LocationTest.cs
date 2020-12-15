using System.Collections.Generic;
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
        
        [Fact]
        public void GetNeighboursLocationsShould_ReturnEmptyList_ThereIsOnlyOneItemInLocationsList()
        {
            var location = new Location(0,0);
            var locations = new List<Location>(){new Location(0, 0)};
            var result = location.GetNeighboursLocations(locations);
            Assert.Null(result);
        }
        
        [Fact]
        public void GetNeighboursLocationsShould_ReturnAListOfOneLocation_WhenThereAre2LocationsInList()
        {
            
            var locations = new List<Location>(){new Location(0, 0), new Location(0, 1)};
            
            var location = new Location(0,0);
            var result = location.GetNeighboursLocations(locations);
            Assert.NotEmpty(result);
            Assert.Equal(0, result[0].X);
            Assert.Equal(1, result[0].Y);
            
            var secondLocation = new Location(0,1);
            var secondResult = secondLocation.GetNeighboursLocations(locations);
            Assert.NotEmpty(secondResult);
            Assert.Equal(0, secondResult[0].X);
            Assert.Equal(0, secondResult[0].Y);
        }
        
        

    }
}