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
            var board = Board.CreateBoard(0);
            Assert.Null(board);
        }
        
        [Fact]
        public void CreateBoardShould_ReturnABoardWithOneSquare_WhenInputIs1()
        {
            var board = Board.CreateBoard(1);

        }
    }
}