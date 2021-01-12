using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class GameTest
    {
         [Fact]
         public void SetUpShould_CreateA4by4HiddenBoard_WhenInputDifficultyLevelIs4()
         {
             const string difficultyLevelInput = "4";
             var input = new MockInput(new[]{difficultyLevelInput});
             var output = new MockOutput();
             var minesGenerator = new MockMinesGenerator();
             var game = new Game(input, output, minesGenerator);
             game.CreateBoard();
             var result = game.Board.ToString();
             const string expectedResult = ". . . . \n" + 
                                           ". . . . \n" + 
                                           ". . . . \n" + 
                                           ". . . . \n";
             
             Assert.Equal(expectedResult, result);
         }        
         
         [Fact]
         public void GameShould_RevealEntireBoardAndWinTheGame_WhenInputLocationMatchesAllHintLocations()
         {
             const string difficultyLevelInput = "2";
             var input = new MockInput(new[]{difficultyLevelInput, "1,0", "1,1"});
             var output = new MockOutput();
             var minesGenerator = new MockMinesGenerator();
             var game = new Game(input, output, minesGenerator);
             game.CreateBoard();
             game.Play();
             var result = game.Board.ToString();
             const string expectedResult = "* * \n" +
                                           "2 2 \n";
             Assert.Equal(expectedResult, result);
             Assert.Equal(GameState.Win, game.State);
         }
         
         [Fact]
         public void GameShould_RevealEntireBoardAndLoseTheGame_WhenInputLocationMatchesMineLocation()
         {
             const string difficultyLevelInput = "4";
             var input = new MockInput(new[]{difficultyLevelInput, "0,0"});
             var output = new MockOutput();
             var minesGenerator = new MockMinesGenerator();
             var game = new Game(input, output, minesGenerator);
             game.CreateBoard();
             game.Play();
             var result = game.Board.ToString();
             const string expectedResult = "* * * * \n" +
                                           "2 3 3 2 \n" +
                                           "0 0 0 0 \n" +
                                           "0 0 0 0 \n";
             
             Assert.Equal(expectedResult, result);
             Assert.Equal(GameState.Lose, game.State);
         }
    }
}