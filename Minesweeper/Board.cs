using System.Collections.Generic;

namespace Minesweeper
{
    public class Board
    {
        public int Size { get; private set; }
        public List<Square> Squares { get; private set; }
        public bool IsRevealed { get; set; } = false;
        private Board(int size)
        {
            Size = size;
            Squares = CreateSquares();
        }

        private List<Square> CreateSquares()
        {
            var squares = new List<Square>();
            if (Size == 0)
            {
                squares = null;
            }
            else
            {
                for (var i = 0; i < Size; i++)
                {
                    for (var j = 0; j < Size; j++)
                    {
                        var location = new Location(i, j);
                        var square = new Square(location);
                        squares.Add(square);
                    }
                }
            }
            return squares;
        }

        public static Board CreateEmptyBoard(int size)
        {
            return new Board(size);
        }
        
        //
        // public void PlaceHints()
        // {
        //     var hints = CreateHints();
        //     Squares.AddRange(hints);
        // }
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
        //
        // private List<Location> DetermineHintsLocations(List<Location> mineLocations)
        // {
        //     return Locations.FindAll(x => !mineLocations.Contains(x));
        // }
        //
        // private List<Location> DetermineMinesLocations()
        // {
        //     return _mines.Select(mine => mine.Location).ToList();
        // }
        //
        // public void RevealAllSquares()
        // {
        //     foreach (var item in Squares.Where(item => item.IsRevealed == false))
        //     {
        //         item.IsRevealed = true;
        //     }
        //
        //     IsRevealed = true;
        // }
        //
        // public void RevealOneSquare(Location location)
        // {
        //     var xValue = location.X;
        //     var yValue = location.Y;
        //     var square = FindSquareUsingLocationValue(xValue, yValue);
        //     square.IsRevealed = true;
        // }
        //
        // public bool OneMineIsRevealed()
        // {
        //     return _mines.Any(item => item.IsRevealed);
        // }
        //
        // public override string ToString()
        // {
        //     var message = "";
        //     for (int i = 0; i < Size; i++)
        //     {
        //         for (int j = 0; j < Size; j++)
        //         {
        //             message += FindSquareUsingLocationValue(i,j).ToString();
        //             message += " ";
        //         }
        //
        //         message += "\n";
        //     }
        //
        //     return message;
        // }
        //
        // private Square FindSquareUsingLocationValue(int x, int y)
        // {
        //     var square = Squares.Find(item => item.Location.X == x && item.Location.Y == y);
        //     return square;
        // }
        //
        // public bool AllHintsAreRevealed()
        // {
        //     return _hints.All(item => item.IsRevealed);
        // }

    }
}