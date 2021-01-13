using System.Linq;

namespace Minesweeper
{
    public static class WinLoseChecker
    {
        public static bool IsWinningConditionWhenAllHintsAreRevealed(Board currentBoard)
        {
            var hints = currentBoard.Squares.Where(item => !item.IsMine);
            return hints.All(item => item.IsRevealed);
        }
        
        public static bool IsLosingConditionWhenOneMineIsRevealed(Board currentBoard)
        {
            var mines = currentBoard.Squares.Where(item => item.IsMine);
            return mines.Any(item => item.IsRevealed);
        }
    }
}