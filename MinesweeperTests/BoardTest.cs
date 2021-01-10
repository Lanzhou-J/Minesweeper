using System.Linq;
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

        [Fact]
        public void GetNeighboursShould_ReturnAnEmptyList_WhenBoardSizeIs1()
        {
            var board = Board.CreateEmptyBoard(1);
            var square = board.Squares[0];
            var neighbours = board.GetNeighbours(square);
            Assert.Empty(neighbours);
        }

        [Fact]
        public void GetNeighboursShould_ReturnAListOf3Item_WhenBoardSizeIs2()
        {
            var board = Board.CreateEmptyBoard(2);
            var square = board.Squares[0];
            var neighbours = board.GetNeighbours(square);
            Assert.Equal(3, neighbours.Count());
        }
        
        [Fact]
        public void GetNeighboursShould_ReturnAListWithoutTheInputSquare_WhenBoardSizeIs2()
        {
            var board = Board.CreateEmptyBoard(2);
            var square = board.Squares[0];
            var neighbours = board.GetNeighbours(square);
            Assert.DoesNotContain(square, neighbours);
        }

        [Fact]
        public void GetNeighboursShould_ReturnAListO8Items_WhenBoardSizeIs3_CurrentSquareIsInTheMiddle()
        {
            var board = Board.CreateEmptyBoard(3);
            var centerLocation = new Location(1,1);
            var square = board.GetSquare(centerLocation);
            var neighbours = board.GetNeighbours(square);
            Assert.Equal(8, neighbours.Count());
        }
        
        [Fact]
        public void GetNeighboursShould_ReturnAListWithoutTheInputItem_WhenBoardSizeIs3_CurrentSquareIsInTheMiddle()
        {
            var board = Board.CreateEmptyBoard(3);
            var centerLocation = new Location(1,1);
            var square = board.GetSquare(centerLocation);
            var neighbours = board.GetNeighbours(square);
            Assert.DoesNotContain(square, neighbours);
        }
        
        [Fact]
        public void GetNeighboursShould_ReturnAListO5Items_WhenBoardSizeIs3_CurrentSquareIsOnTheEdge()
        {
            var board = Board.CreateEmptyBoard(3);
            var edgeLocation = new Location(1,0);
            var square = board.GetSquare(edgeLocation);
            var neighbours = board.GetNeighbours(square);
            Assert.Equal(5, neighbours.Count());
        }

        [Fact]
        public void GetNeighboursShould_ReturnAListO3Items_WhenBoardSizeIs3_CurrentSquareIsOnTheCorner()
        {
            var board = Board.CreateEmptyBoard(3);
            var cornerLocation = new Location(0,0);
            var square = board.GetSquare(cornerLocation);
            var neighbours = board.GetNeighbours(square);
            Assert.Equal(3, neighbours.Count());
        }

        [Fact]
        public void GetSquareShould_ReturnSquareWithCorrectLocation()
        {
            var board = Board.CreateEmptyBoard(3);
            var location = new Location(0, 0); 
            var square = board.GetSquare(location);
            var locationX = square.Location.X;
            var locationY = square.Location.Y;
            Assert.Equal(0, locationX);
            Assert.Equal(0, locationY);
        }
        
        [Fact]
        public void RevealSquaresShould_SetAllSquaresToIsRevealed()
        {
            var board = Board.CreateEmptyBoard(2);
            foreach (var item in board.Squares)
            {
                Assert.False(item.IsRevealed);
            }
            board.RevealAllSquares();
            foreach (var item in board.Squares)
            {
                Assert.True(item.IsRevealed);
            }
        }
        
        [Fact]
        public void ToStringShould_ReturnExpectedString_WhenThereIsNoMinesInASize1Board()
        {
            const string expectedString = ". \n";
            var board = Board.CreateEmptyBoard(1);
            var minesGenerator = new RandomMinesGenerator();
            var hintsCalculator = new HintGenerator();
            minesGenerator.PlaceMines(0, board);
            HintGenerator.SetHints(board);
            Assert.Equal(expectedString, board.ToString());
        }
        
        [Fact]
        public void ToStringShould_ReturnExpectedString_WhenThereIsNoMinesInASize2Board()
        {
            var expectedString = ". . \n" + ". . \n";
            var board = Board.CreateEmptyBoard(2);
            var minesGenerator = new RandomMinesGenerator();
            var hintsCalculator = new HintGenerator();
            minesGenerator.PlaceMines(0, board);
            HintGenerator.SetHints(board);
            Assert.Equal(expectedString, board.ToString());
        }
        
        [Fact]
        public void ToStringShould_ReturnExpectedString_WhenThereIs1RevealedMineInASize1Board()
        {
            const string expectedHiddenString = ". \n";
            const string expectedRevealedString = "* \n";
            var board = Board.CreateEmptyBoard(1);
            var minesGenerator = new RandomMinesGenerator();
            var hintsCalculator = new HintGenerator();
            minesGenerator.PlaceMines(1,board);
            HintGenerator.SetHints(board);
            Assert.Equal(expectedHiddenString, board.ToString());
            board.RevealAllSquares();
            Assert.Equal(expectedRevealedString, board.ToString());
        }
        
        [Fact]
        public void ToStringShould_ReturnExpectedString_WhenThereIs1RevealedTopLeftMineInASize2Board()
        {
            var mineGenerator = new MockMinesGenerator();
            var hintsCalculator = new HintGenerator();
            const string expectedString = "* 1 \n" + "1 1 \n";
            var board = Board.CreateEmptyBoard(2);
            mineGenerator.PlaceMines(1, board);
            HintGenerator.SetHints(board);
            board.RevealAllSquares();
            Assert.Equal(expectedString, board.ToString());
        }

        [Fact]
        public void HasLocationShould_ReturnTrue_WhenLocationIsOnTheBoard()
        {
            var board = Board.CreateEmptyBoard(2);
            var location = new Location(0,0);
            var result = board.HasLocation(location);
            Assert.True(result);
        }
        
        [Fact]
        public void HasLocationShould_ReturnFalse_WhenLocationIsNotOnTheBoard()
        {
            var board = Board.CreateEmptyBoard(2);
            var location = new Location(3,3);
            var result = board.HasLocation(location);
            Assert.False(result);
        }

    }
}