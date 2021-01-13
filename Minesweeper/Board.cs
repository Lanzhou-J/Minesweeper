using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class Board
    {
        public int Length { get; }
        public IList<Square> Squares { get; }
        public bool IsRevealed { get; private set; }
        private Board(int length)
        {
            Length = length;
            Squares = CreateSquares();
            IsRevealed = false;
        }

        private IList<Square> CreateSquares()
        {
            var squares = new List<Square>();
            if (Length == 0)
            {
                squares = null;
            }
            else
            {
                for (var xValue = 0; xValue < Length; xValue++)
                {
                    for (var yValue = 0; yValue < Length; yValue++)
                    {
                        var location = new Location(xValue, yValue);
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
            foreach (var square in Squares)
            {
                square.IsRevealed = true;
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
            var square = Squares.SingleOrDefault(item => item.Location.Equals(location));
            return square;
        }

        public override string ToString()
        {
            var message = "";
            for (var xValue = 0; xValue < Length; xValue++)
            {
                for (var yValue = 0; yValue < Length; yValue++)
                {
                    var location = new Location(xValue, yValue);
                    message += GetSquare(location).ToString();
                    message += " ";
                }
        
                message += "\n";
            }
        
            return message;
        }

        public IEnumerable<Square> GetNeighbours(Square square)
        {
            var squareX = square.Location.X;
            var squareY = square.Location.Y;
            var neighbours = new List<Square>();
            AddNeighboursWithinThreeByThreeAreaToList(squareX, squareY, neighbours);
            return neighbours;
        }

        private void AddNeighboursWithinThreeByThreeAreaToList(int centerX, int centerY, ICollection<Square> neighbours)
        {
            for (var deltaX = -1; deltaX <= 1; deltaX++)
            {
                for (var deltaY = -1; deltaY <= 1; deltaY++)
                {
                    if (deltaX == 0 && deltaY == 0) continue;
                    var neighbourXValue = centerX + deltaX;
                    var neighbourYValue = centerY + deltaY;
                    var neighbourLocation = new Location(neighbourXValue, neighbourYValue);

                    if (HasLocation(neighbourLocation))
                    {
                        var neighbour = GetSquare(neighbourLocation);
                        neighbours.Add(neighbour);
                    }
                }
            }
        }

        public bool HasLocation(Location location)
        {
            return location.X < Length && location.X >= 0 && location.Y < Length && location.Y >= 0;
        }

    }
}