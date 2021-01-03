using System.Collections.Generic;
using System.Linq;
using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class RandomMinesGeneratorTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(9)]
        public void PlaceMinesShould_CreateCorrectNumberOfMines(int number)
        {
            var board = Board.CreateEmptyBoard(3);
            var minesGenerator = new RandomMinesGenerator();
            minesGenerator.PlaceMines(number, board);
            var mines = board.Squares.Where(item => item.IsMine);
            Assert.Equal(number, mines.Count());
        }
    }
}