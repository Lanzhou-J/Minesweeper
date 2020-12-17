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
            var locations = new List<Location>(){location};
            var result = location.GetNeighboursLocations(locations);
            Assert.Null(result);
        }
        
        [Fact]
        public void GetNeighboursLocationsShould_ReturnAListOfOneLocation_WhenThereAre2LocationsInList()
        {
            var left = new Location(0,0);
            var right = new Location(0,1);
            
            var locations = new List<Location>(){left, right};
            
            var leftNeighbours = left.GetNeighboursLocations(locations);
            Assert.Single(leftNeighbours);
            Assert.Contains(right, leftNeighbours);

            var rightNeighbours = right.GetNeighboursLocations(locations);
            Assert.Single(rightNeighbours);
            Assert.Contains(left, rightNeighbours);
        }
        
        [Fact]
        public void GetNeighboursLocationsShould_ReturnAListO2Locations_WhenThereAre3LocationsInList()
        {
            var left = new Location(0,0);
            var middle = new Location(0,1);
            var right = new Location(0,2);
            var locations = new List<Location>(){left, middle, right};
            
            var leftNeighbours = left.GetNeighboursLocations(locations);
            Assert.Equal(2, leftNeighbours.Count);
            Assert.Contains(middle, leftNeighbours);
            Assert.Contains(right, leftNeighbours);
        }
        
        [Fact]
        public void GetNeighboursLocationsShould_ReturnAListO3Locations_WhenThereAre4LocationsInList()
        {
            var topLeft = new Location(0,0);
            var topRight = new Location(0,1);
            var bottomLeft = new Location(1,0);
            var bottomRight = new Location(1,1);
            
            var locations = new List<Location>(){topLeft, topRight, bottomLeft, bottomRight};
            
            var result = topLeft.GetNeighboursLocations(locations);
            Assert.Equal(3, result.Count);
        }
    }
}