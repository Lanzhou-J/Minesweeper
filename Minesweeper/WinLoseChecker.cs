using System.Linq;

namespace Minesweeper
{
    public static class WinLoseChecker
    {
        public static bool IsWinningCondition(Board currentBoard)
        {
            return AllHintsAreRevealed(currentBoard);
        }
        
        public static bool IsLosingCondition(Board currentBoard)
        {
            return OneMineIsRevealed(currentBoard);
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