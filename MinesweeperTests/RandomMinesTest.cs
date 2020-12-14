using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class RandomMinesTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void NewRandomMinesShould_CreateCorrectNumberOfMines(int number)
        {
            var mines = new RandomMines(number);
            Assert.Equal(number, mines.Count);
        }
    }
}