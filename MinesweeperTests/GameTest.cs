using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class GameTest
    {
        private Square _empty = Square.Empty;
        [Fact]
        public void StartShould_SetAnEmptyBoardWith4RowsAnd4Columns_WhenInputDifficultyLevelIs4()
        {
            var input = new MockInput();
            var output = new MockOutput();
            var game = new Game(input, output);
            game.Start();
            var expectedResult = new Square[4,4]{
                {_empty, _empty, _empty, _empty},
                {_empty, _empty, _empty, _empty},
                {_empty, _empty, _empty, _empty},
                {_empty, _empty, _empty, _empty},
            };

        }
    }
}