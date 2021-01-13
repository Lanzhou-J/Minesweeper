using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public static class HintGenerator
    {
        public static void SetHints(Board board)
        {
            if (BoardSizeIsTooSmall(board)) return;
            if (BoardDoesNotContainAnyMine(board)) return;
            var mines = GetMines(board);
            foreach (var item in mines)
            {
                IncrementAllNeighboursHintValueByOne(board, item);
            }
        }

        private static IEnumerable<Square> GetMines(Board board)
        {
            return board.Squares.Where(item => item.IsMine);
        }

        private static void IncrementAllNeighboursHintValueByOne(Board board, Square item)
        {
            var neighbours = board.GetNeighbours(item);
            foreach (var neighbour in neighbours)
            {
                neighbour.Hint += 1;
            }
        }

        private static bool BoardSizeIsTooSmall(Board board)
        {
            return board.Length < 2;
        }

        private static bool BoardDoesNotContainAnyMine(Board board)
        {
            return !board.Squares.Any(square => square.IsMine);
        }
        
    }
}