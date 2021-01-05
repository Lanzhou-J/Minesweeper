using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class HintCalculator
    {
        public void SetHints(Board board)
        {
            if (BoardSizeIsTooSmall(board)) return;
            if (BoardDoesNotContainAnyMine(board)) return;
            var mines = GetMines(board);
            foreach (var item in mines)
            {
                IncrementAllNeighboursHintValue(board, item);
            }
        }

        private static IEnumerable<Square> GetMines(Board board)
        {
            return board.Squares.Where(item => item.IsMine);
        }

        private static void IncrementAllNeighboursHintValue(Board board, Square item)
        {
            var neighbours = board.GetNeighbours(item);
            foreach (var neighbour in neighbours)
            {
                neighbour.IncrementHintValueByOne();
            }
        }

        private static bool BoardSizeIsTooSmall(Board board)
        {
            return board.Size < 2;
        }

        private static bool BoardDoesNotContainAnyMine(Board board)
        {
            return !board.Squares.Any(square => square.IsMine);
        }
        
    }
}