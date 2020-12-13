using System;
using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class BoardTest
    {
        [Fact]
        public void CreateBoardShould_ReturnNull_WhenInputIs0()
        {
            var board = Board.CreateEmptyBoard(0);
            Assert.Null(board);
        }
        
        [Fact]
        public void CreateEmptyBoardShould_CreateASize1Board_WhenInputIs1()
        {
            var board = Board.CreateEmptyBoard(1);
            Assert.Equal(1, board.Size);
            Assert.Equal(1, board.Squares.GetLength(0));
            Assert.Equal(1, board.Squares.GetLength(1));
        }
        
        [Fact]
        public void CreateEmptyBoardShould_CreateABoardWithASquareNotMine_WhenInputIs1()
        {
            var board = Board.CreateEmptyBoard(1);

            var square = board.Squares[0, 0];

            Assert.False(square.IsMine);
        }
        
        [Fact]
        public void CreateBoardShould_CreateASize2BoardWithSquaresLengthOf2_WhenInputIs2()
        {
            var board = Board.CreateEmptyBoard(2);
            Assert.Equal(2, board.Size);
            Assert.Equal(2, board.Squares.GetLength(0));
            Assert.Equal(2, board.Squares.GetLength(1));
        }
    }
}