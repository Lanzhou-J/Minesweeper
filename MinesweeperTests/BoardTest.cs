using System;
using Xunit;

namespace MinesweeperTests
{
    public class BoardTest
    {
        [Fact]
        public void CreateBoardShould_ReturnNull_WhenInputIs0()
        {
            var board = Board.createBoard(0);
            Assert.Null(board);
        }
    }
}