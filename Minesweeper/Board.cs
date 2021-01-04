using System.Collections.Generic;
using System.Linq;

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
        public void RevealAllSquares()
        {
            foreach (var item in Squares)
            {
                item.IsRevealed = true;
            }
        
            IsRevealed = true;
        }
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
        public override string ToString()
        {
            var message = "";
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    message += FindSquareUsingLocationValue(i,j).ToString();
                    message += " ";
                }
        
                message += "\n";
            }
        
            return message;
        }
        
        private Square FindSquareUsingLocationValue(int x, int y)
        {
            var square = Squares.Find(item => item.Location.X == x && item.Location.Y == y);
            return square;
        }

        public List<Square> GetNeighbours(Square square)
        {
            return new List<Square>();
        }

        // public bool AllHintsAreRevealed()
        // {
        //     return _hints.All(item => item.IsRevealed);
        // }

    }
}