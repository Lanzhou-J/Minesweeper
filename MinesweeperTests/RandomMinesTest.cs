using System.Collections.Generic;
using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class RandomMinesTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(9)]
        public void NewRandomMinesShould_CreateCorrectNumberOfMines(int number)
        {
            var locations = GetThreeByThreeBoardLocations();

            var mines = new RandomMines(number, locations);
            Assert.Equal(number, mines.MineList.Count);
        }

        private static List<Location> GetThreeByThreeBoardLocations()
        {
            var locations = new List<Location>();
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    locations.Add(new Location(i, j));
                }
            }
            return locations;
        }
    }
}