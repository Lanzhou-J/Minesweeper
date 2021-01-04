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
        
        //
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