using System.Collections.Generic;
using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class LocationTest
    {
        [Fact]
        public void FindNeighboursFromLocationsShould_ReturnEmptyList_WhenNoArgument()
        {
            var location = new Location(0,0);
            var result = location.FindNeighboursFromLocations();
            Assert.Null(result);
        }
        
        [Fact]
        public void FindNeighboursFromLocationsShould_ReturnEmptyList_ThereIsOnlyOneItemInLocationsList()
        {
            var location = new Location(0,0);
            var locations = new List<Location>(){location};
            var result = location.FindNeighboursFromLocations(locations);
            Assert.Null(result);
        }
        
        [Fact]
        public void FindNeighboursFromLocationsShould_ReturnAListOfOneItem_WhenThereAre2LocationsInList()
        {
            var left = new Location(0,0);
            var right = new Location(0,1);
            
            var locations = new List<Location>(){left, right};
            
            var leftNeighbours = left.FindNeighboursFromLocations(locations);
            Assert.Single(leftNeighbours);
            Assert.Contains(right, leftNeighbours);

            var rightNeighbours = right.FindNeighboursFromLocations(locations);
            Assert.Single(rightNeighbours);
            Assert.Contains(left, rightNeighbours);
        }
        
        [Fact]
        public void FindNeighboursFromLocationsShould_ReturnAListO2Items_WhenThereAre3LocationsInList()
        {
            var left = new Location(0,0);
            var middle = new Location(0,1);
            var right = new Location(0,2);
            var locations = new List<Location>(){left, middle, right};
            
            var leftNeighbours = left.FindNeighboursFromLocations(locations);
            Assert.Single(leftNeighbours);
            Assert.Contains(middle, leftNeighbours);
        }
        
        [Fact]
        public void FindNeighboursFromLocationsShould_ReturnAListO3Items_WhenLocationsRepresentA2by2Area()
        {
            var topLeft = new Location(0,0);
            var topRight = new Location(0,1);
            var bottomLeft = new Location(1,0);
            var bottomRight = new Location(1,1);
            
            var locations = new List<Location>(){topLeft, topRight, bottomLeft, bottomRight};
            var topLeftNeighbours = topLeft.FindNeighboursFromLocations(locations);
            
            Assert.Equal(3, topLeftNeighbours.Count);
            
            Assert.Contains(topRight, topLeftNeighbours);
            Assert.Contains(bottomLeft, topLeftNeighbours);
            Assert.Contains(bottomRight, topLeftNeighbours);
        }
        
        [Fact]
        public void FindNeighboursFromLocationsShould_ReturnAListO8Items_WhenLocationsRepresentA3by3Area_CurrentCellIsInTheMiddle()
        {
            var topLeft = new Location(0,0);
            var topMiddle = new Location(0,1);
            var topRight = new Location(0,2);
            var middleLeft = new Location(1,0);
            var center = new Location(1,1);
            var middleRight = new Location(1,2);
            var bottomLeft = new Location(2,0);
            var bottomMiddle = new Location(2,1);
            var bottomRight = new Location(2,2);
            
            var locations = new List<Location>(){topLeft, topMiddle, topRight, middleLeft, center, middleRight, bottomLeft, bottomMiddle, bottomRight};
            var topLeftNeighbours = center.FindNeighboursFromLocations(locations);
            
            Assert.Equal(8, topLeftNeighbours.Count);
            
            Assert.Contains(topLeft, topLeftNeighbours);
            Assert.Contains(topMiddle, topLeftNeighbours);
            Assert.Contains(topRight, topLeftNeighbours);
            Assert.Contains(middleLeft, topLeftNeighbours);
            Assert.Contains(middleRight, topLeftNeighbours);
            Assert.Contains(bottomLeft, topLeftNeighbours);
            Assert.Contains(bottomMiddle, topLeftNeighbours);
            Assert.Contains(bottomRight, topLeftNeighbours);
        }
        
        [Fact]
        public void FindNeighboursFromLocationsShould_ReturnAListO3Items_WhenLocationsRepresentA3by3Area_CurrentCellIsTopLeft()
        {
            var topLeft = new Location(0,0);
            var topMiddle = new Location(0,1);
            var topRight = new Location(0,2);
            var middleLeft = new Location(1,0);
            var center = new Location(1,1);
            var middleRight = new Location(1,2);
            var bottomLeft = new Location(2,0);
            var bottomMiddle = new Location(2,1);
            var bottomRight = new Location(2,2);
            
            var locations = new List<Location>(){topLeft, topMiddle, topRight, middleLeft, center, middleRight, bottomLeft, bottomMiddle, bottomRight};
            var topLeftNeighbours = topLeft.FindNeighboursFromLocations(locations);
            
            Assert.Equal(3, topLeftNeighbours.Count);
            
            Assert.Contains(topMiddle, topLeftNeighbours);
            Assert.Contains(middleLeft, topLeftNeighbours);
            Assert.Contains(center, topLeftNeighbours);
        }

        [Fact]
        public void EqualShould_ReturnTrue_When2LocationsXValueAndYValueAreTheSame()
        {
            var location1 = new Location(1,1);
            var location2 = new Location(1,1);
            Assert.True(location1.Equal(location2));
        }
        
        [Fact]
        public void EqualShould_ReturnFalse_When2LocationsXValueAndYValueAreTheSame()
        {
            var location1 = new Location(1,1);
            var location2 = new Location(1,2);
            Assert.False(location1.Equal(location2));
        }
    }
}