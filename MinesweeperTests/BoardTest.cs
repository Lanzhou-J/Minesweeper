using System;
using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class BoardTest
    {
        private SquareState _empty = SquareState.Empty;
        private SquareState _mine = SquareState.Mine;
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
        public void CreateBoardShould_CreateASize1BoardWithEmptySquareState_WhenInputIs1()
        {
            var board = Board.CreateBoard(1);
            var expectedResult = new []{
                new[]{_empty}
            };
            Assert.Equal(expectedResult, board.Squares);
        }
    }
}