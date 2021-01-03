using System.Linq;

namespace Minesweeper
{
    public class HintCalculator
    {
        public void SetHints(Board board)
        {
            foreach (var item in board.Squares)
            {
                if (board.Size < 2) continue;
                if (!board.Squares.Any(square => square.IsMine)) continue;
                if (!item.IsMine)
                {
                    item.SetHintValue(1);
                }
            }
        }
    }
}