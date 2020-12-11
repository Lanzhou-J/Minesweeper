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
        }
        
        [Fact]
        public void CreateBoardShould_CreateASize1BoardWithMineSquareState_WhenInputIs1()
        {
            var board = Board.CreateBoard(1);
            var expectedResult = new []{
                new[]{_mine}
            };
            Assert.Equal(expectedResult, board.Squares);
        }
    }
}