using System;
using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class BoardTest
    {
        private Square _empty = Square.Empty;
        private Square _mine = Square.Mine;
        [Fact]
        public void CreateBoardShould_ReturnNull_WhenInputIs0()
        {
            var board = Board.CreateBoard(0);
            Assert.Null(board);
        }
        
        [Fact]
        public void CreateBoardShould_CreateASize1Board_WhenInputIs1()
        {
            var board = Board.CreateBoard(1);
            Assert.Equal(1, board.Size);
            Assert.Single(board.Squares);
        }
        
        [Fact]
        public void CreateBoardShould_CreateABoardWithEmptySquare_WhenInputIs1()
        {
            var board = Board.CreateBoard(1);
            var expectedResult = new []{
                new[]{_empty}
            };
            Assert.Equal(expectedResult, board.Squares);
        }
        
        [Fact]
        public void CreateBoardShould_CreateASize2BoardWithSquaresLengthOf2_WhenInputIs2()
        {
            var board = Board.CreateBoard(2);
            Assert.Equal(2, board.Size);
            Assert.Equal(2, board.Squares.Length);
        }
    }
}