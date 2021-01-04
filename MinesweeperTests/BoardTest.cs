using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class BoardTest
    { 
        [Theory]
        [InlineData(0,0,0)]
        [InlineData(0,1,1)]
        [InlineData(1,0,2)]
        [InlineData(1,1,3)]
       public void CreateEmptyBoardShould_CreateSquaresWithCorrectLocations(int expectedX, int expectedY, int index)
       {
           var board = Board.CreateEmptyBoard(2);
           var squares = board.Squares;
           var location = squares[index].Location;
           var locationX = location.X;
           var locationY = location.Y;
            
           Assert.Equal(expectedX, locationX);
           Assert.Equal(expectedY, locationY);
       }
        
        [Fact]
        public void CreateEmptyBoardShould_CreateASize1Board_WhenInputIs1()
        {
            var board = Board.CreateEmptyBoard(1);
            Assert.Equal(1, board.Size);
        }
        
        [Fact]
        public void CreateEmptyBoardShould_CreateASize2Board_WhenInputIs2()
        {
            var board = Board.CreateEmptyBoard(2);
            Assert.Equal(2, board.Size);
        }
        

        //
        // [Fact]
        // public void CreateHintsShould_Return2HintsWithValue2_WhenThereAre2Mines_InASize2Board()
        // {
        //     var board = Board.CreateEmptyBoardBasedOnSize(2);
        //     board.PlaceMines(2);
        //
        //     var hints = board.CreateHints();
        //     Assert.Equal(2, hints.Count);
        //     foreach (var item in hints)
        //     {
        //         Assert.Equal(2, item.Value);
        //     }
        // }
        
        // [Fact]
        // public void CreateHintsShould_Return8Hints_WhenThereIs1TopLeftMine_InASize3Board()
        // {
        //     var board = Board.CreateEmptyBoardBasedOnSize(3, new MockMinesGenerator());
        //     board.PlaceMines(1);
        //
        //     var hints = board.CreateHints();
        //     Assert.Equal(8, hints.Count);
        //
        //     var bottomRightHint = hints.Find(x => x.Location.X == 2 && x.Location.Y == 2);
        //     var bottomMiddleHint = hints.Find(x => x.Location.X == 2 && x.Location.Y == 1);
        //     var bottomLeftHint = hints.Find(x => x.Location.X == 2 && x.Location.Y == 0);
        //     var topMiddleHint = hints.Find(x => x.Location.X == 0 && x.Location.Y == 1);
        //     var middleLeftHint = hints.Find(x => x.Location.X == 1 && x.Location.Y == 0);
        //     var centerHint = hints.Find(x => x.Location.X == 1 && x.Location.Y == 1);
        //     Assert.Equal(0, bottomRightHint.Value);
        //     Assert.Equal(0, bottomMiddleHint.Value);
        //     Assert.Equal(0, bottomLeftHint.Value);
        //     Assert.Equal(1, topMiddleHint.Value);
        //     Assert.Equal(1, middleLeftHint.Value);
        //     Assert.Equal(1, centerHint.Value);
        //     
        // }
        //
        // [Fact]
        // public void RevealSquaresShould_SetAllSquaresToIsRevealed()
        // {
        //     var board = Board.CreateEmptyBoardBasedOnSize(2);
        //     foreach (var item in board.Squares)
        //     {
        //         Assert.False(item.IsRevealed);
        //     }
        //     board.RevealAllSquares();
        //     foreach (var item in board.Squares)
        //     {
        //         Assert.True(item.IsRevealed);
        //     }
        // }
        //
        [Fact]
        public void ToStringShould_ReturnExpectedString_WhenThereIsNoMinesInASize1Board()
        {
            const string expectedString = ". \n";
            var board = Board.CreateEmptyBoard(1);
            var minesGenerator = new RandomMinesGenerator();
            var hintsCalculator = new HintCalculator();
            minesGenerator.PlaceMines(0, board);
            hintsCalculator.SetHints(board);
            Assert.Equal(expectedString, board.ToString());
        }
        
        [Fact]
        public void ToStringShould_ReturnExpectedString_WhenThereIsNoMinesInASize2Board()
        {
            var expectedString = ". . \n" + ". . \n";
            var board = Board.CreateEmptyBoard(2);
            var minesGenerator = new RandomMinesGenerator();
            var hintsCalculator = new HintCalculator();
            minesGenerator.PlaceMines(0, board);
            hintsCalculator.SetHints(board);
            Assert.Equal(expectedString, board.ToString());
        }
        
        [Fact]
        public void ToStringShould_ReturnExpectedString_WhenThereIs1RevealedMineInASize1Board()
        {
            const string expectedHiddenString = ". \n";
            const string expectedRevealedString = "* \n";
            var board = Board.CreateEmptyBoard(1);
            var minesGenerator = new RandomMinesGenerator();
            var hintsCalculator = new HintCalculator();
            minesGenerator.PlaceMines(1,board);
            hintsCalculator.SetHints(board);
            Assert.Equal(expectedHiddenString, board.ToString());
            board.RevealAllSquares();
            Assert.Equal(expectedRevealedString, board.ToString());
        }
        
        [Fact]
        public void ToStringShould_ReturnExpectedString_WhenThereIs1RevealedTopLeftMineInASize2Board()
        {
            var mineGenerator = new MockMinesGenerator();
            var hintsCalculator = new HintCalculator();
            const string expectedString = "* 1 \n" + "1 1 \n";
            var board = Board.CreateEmptyBoard(2);
            mineGenerator.PlaceMines(1, board);
            hintsCalculator.SetHints(board);
            board.RevealAllSquares();
            Assert.Equal(expectedString, board.ToString());
        }

    }
}