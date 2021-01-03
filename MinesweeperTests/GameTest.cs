// using Minesweeper;
// using Xunit;
//
// namespace MinesweeperTests
// {
//     public class GameTest
//     {
//         [Fact]
//         public void SetUpShould_CreateA4by4HiddenBoard_WhenInputDifficultyLevelIs4()
//         {
//             var difficultyLevelInput = "4";
//             var input = new MockInput(new[]{difficultyLevelInput});
//             var output = new MockOutput();
//             var inputParser = new InputParser();
//             var player = new Player();
//             var minesGenerator = new MockMinesGenerator();
//             var game = new Game(input, output, inputParser, player, minesGenerator);
//             game.SetUpBoard();
//             var result = game.Board.ToString();
//             const string expectedResult = ". . . . \n" + ". . . . \n" + ". . . . \n" + ". . . . \n";
//             
//             Assert.Equal(expectedResult, result);
//         }        [Fact]
//         public void GameShould_RevealEntireBoardAndPlayerWins_WhenInputLocationMatchesAllHintLocations()
//         {
//             var difficultyLevelInput = "2";
//             var input = new MockInput(new[]{difficultyLevelInput, "1,0", "1,1"});
//             var output = new MockOutput();
//             var inputParser = new InputParser();
//             var player = new Player();
//             var minesGenerator = new MockMinesGenerator();
//             var game = new Game(input, output, inputParser, player, minesGenerator);
//             game.SetUpBoard();
//             game.Play();
//             var result = game.Board.ToString();
//             const string expectedResult = "* * \n" +
//                                           "2 2 \n";
//             Assert.Equal(expectedResult, result);
//             Assert.Equal("Winner",player.ToString());
//         }
//         
//         
//         
//         [Fact]
//         public void GameShould_RevealEntireBoard_WhenInputLocationMatchesMineLocation()
//         {
//             var difficultyLevelInput = "4";
//             var input = new MockInput(new[]{difficultyLevelInput, "0,0"});
//             var output = new MockOutput();
//             var inputParser = new InputParser();
//             var player = new Player();
//             var minesGenerator = new MockMinesGenerator();
//             var game = new Game(input, output, inputParser, player, minesGenerator);
//             game.SetUpBoard();
//             game.Play();
//             var result = game.Board.ToString();
//             const string expectedResult = "* * * * \n" +
//                                           "2 3 3 2 \n" +
//                                           "0 0 0 0 \n" +
//                                           "0 0 0 0 \n";
//             
//             Assert.Equal(expectedResult, result);
//         }
//     }
// }