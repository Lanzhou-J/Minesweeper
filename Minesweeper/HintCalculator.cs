using System.Linq;

namespace Minesweeper
{
    public class HintCalculator
    {
        public void SetHints(Board board)
        {
            if (board.Size < 2 || BoardDoesNotContainAnyMine(board)) return;
            foreach (var item in board.Squares)
            {   if (!item.IsMine) continue;
                var neighbours = board.GetNeighbours(item);
                foreach (var neighbour in neighbours)
                {
                    neighbour.IncrementHint();
                }
            }
        }

        private static bool BoardDoesNotContainAnyMine(Board board)
        {
            return !board.Squares.Any(square => square.IsMine);
        }
        
    }
}