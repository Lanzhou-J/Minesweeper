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
            var xValue = location.X;
            var yValue = location.Y;
            var square = FindSquareUsingLocationValue(xValue, yValue);
            square.IsRevealed = true;
        }
        
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
                    var neighbour = GetSquare(xValue, yValue);
                    if (neighbour != null)
                    {
                        neighbours.Add(neighbour);
                    }
                }
            }
        }

        public Square GetSquare(int locationX, int locationY)
        {
            var square = Squares.Find(item => item.Location.X == locationX && item.Location.Y == locationY);
            return square;
        }
        
        public bool OneMineIsRevealed()
        {
            var mines = Squares.FindAll(item => item.IsMine);
            return mines.Any(item => item.IsRevealed);
        }
        
        public bool AllHintsAreRevealed()
        {
            var hints = Squares.FindAll(item => !item.IsMine);
            return hints.All(item => item.IsRevealed);
        }

    }
}