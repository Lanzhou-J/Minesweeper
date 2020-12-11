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
            var board = Board.CreateEmptyBoard(0);
            Assert.Null(board);
        }
        
        [Fact]
        public void CreateBoardShould_CreateASize1Board_WhenInputIs1()
        {
            var board = Board.CreateEmptyBoard(1);
            Assert.Equal(1, board.Size);
            Assert.Equal(1, board.Squares.GetLength(0));
            Assert.Equal(1, board.Squares.GetLength(1));
        }
        
        [Fact]
        public void CreateBoardShould_CreateABoardWithEmptySquare_WhenInputIs1()
        {
            var board = Board.CreateEmptyBoard(1);
            var expectedResult = new Square[1,1]{
                {_empty}
            };
            Assert.Equal(expectedResult, board.Squares);
        }
        
        [Fact]
        public void CreateBoardShould_CreateASize2BoardWithSquaresLengthOf2_WhenInputIs2()
        {
            var board = Board.CreateEmptyBoard(2);
            Assert.Equal(2, board.Size);
            Assert.Equal(2, board.Squares.GetLength(0));
            Assert.Equal(2, board.Squares.GetLength(1));
        }
        
        [Fact]
        public void CreateBoardShould_CreateABoardWithAllEmptyItems_WhenInputIs2()
        {
            var board = Board.CreateEmptyBoard(2);
            var expectedResult = new Square[2,2]{
                {_empty, _empty},
                {_empty, _empty}
            };
        }
    }
}