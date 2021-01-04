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

        // public List<Hint> CreateHints()
        // {
        //     _mineLocations = DetermineMinesLocations();
        //
        //     var hintLocations = DetermineHintsLocations(_mineLocations);
        //     
        //     _hints = new List<Hint>();
        //
        //     foreach (var item in hintLocations)
        //     {
        //         var neighbours = item.FindNeighboursFromLocations(Locations);
        //         var mineNeighbours = _mineLocations.FindAll(x => neighbours.Contains(x));
        //         var mineNeighboursCount = mineNeighbours.Count;
        //         
        //         var hint = new Hint(item, mineNeighboursCount);
        //         _hints.Add(hint);
        //     }
        //     
        //     return _hints;
        // }
    }
}