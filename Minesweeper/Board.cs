using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class Board
    {
        public int Size { get; private set; }
        public List<Square> Squares { get; private set; }
        public bool IsRevealed { get; private set; }
        private Board(int size)
        {
            Size = size;
            Squares = CreateSquares();
            IsRevealed = false;
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

        public void RevealAllSquares()
        {
            foreach (var item in Squares)
            {
                item.IsRevealed = true;
            }
        
            IsRevealed = true;
        }
        
        public void RevealOneSquare(Location location)
        {
            var square = GetSquare(location);
            square.IsRevealed = true;
        }

        public Square GetSquare(Location location)
        {
            var square = Squares.Find(item => item.Location.Equals(location));
            return square;
        }

        public override string ToString()
        {
            var message = "";
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    var location = new Location(i, j);
                    message += GetSquare(location).ToString();
                    message += " ";
                }
        
                message += "\n";
            }
        
            return message;
        }

        public List<Square> GetNeighbours(Square square)
        {
            var squareX = square.Location.X;
            var squareY = square.Location.Y;
            var neighbours = new List<Square>();
            AddExistingNeighboursWithinThreeByThreeAreaToList(squareX, squareY, neighbours);
            return neighbours;
        }

        private void AddExistingNeighboursWithinThreeByThreeAreaToList(int squareX, int squareY, List<Square> neighbours)
        {
            for (var i = -1; i <= 1; i++)
            {
                for (var j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;
                    var xValue = squareX + i;
                    var yValue = squareY + j;
                    var location = new Location(xValue, yValue);
                    var neighbour = GetSquare(location);
                    if (neighbour != null)
                    {
                        neighbours.Add(neighbour);
                    }
                }
            }
        }

        // public Square GetSquare(int locationX, int locationY)
        // {
        //     var square = Squares.Find(item => item.Location.X == locationX && item.Location.Y == locationY);
        //     return square;
        // }

    }
}