// using System.Collections.Generic;
// using Minesweeper;
// using Xunit;
//
// namespace MinesweeperTests
// {
//     public class RandomMinesGeneratorTest
//     {
//         [Theory]
//         [InlineData(1)]
//         [InlineData(5)]
//         [InlineData(9)]
//         public void NewRandomMinesShould_CreateCorrectNumberOfMines(int number)
//         {
//             var locations = GetThreeByThreeBoardLocations();
//             var minesGenerator = new RandomMinesGenerator();
//
//             var mines = minesGenerator.CreateMines(number, locations);
//             Assert.Equal(number, mines.Count);
//         }
//
//         private static List<Location> GetThreeByThreeBoardLocations()
//         {
//             var locations = new List<Location>();
//             for (var i = 0; i < 3; i++)
//             {
//                 for (var j = 0; j < 3; j++)
//                 {
//                     locations.Add(new Location(i, j));
//                 }
//             }
//             return locations;
//         }
//     }
// }