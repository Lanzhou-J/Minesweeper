using System.Linq;

namespace Minesweeper
{
    public static class Rule
    {
        public static bool IsWinningCondition(Board board)
        {
            return AllHintsAreRevealed(board);
        }
        
        public static bool IsLosingCondition(Board board)
        {
            return OneMineIsRevealed(board);
        }

        private static bool OneMineIsRevealed(Board board)
        {
            var mines = board.Squares.FindAll(item => item.IsMine);
            return mines.Any(item => item.IsRevealed);
        }

        private static bool AllHintsAreRevealed(Board board)
        {
            var hints = board.Squares.FindAll(item => !item.IsMine);
            return hints.All(item => item.IsRevealed);
        }
    }
}