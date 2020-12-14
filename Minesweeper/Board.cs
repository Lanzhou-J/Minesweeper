using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class Board
    {
        private readonly Random _random = new Random();
        private Board(int size)
        {
            Size = size;
            Squares = SetSquares();
        }

        private List<ISquare> SetSquares()
        {
            var squares = new List<ISquare>();
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    var location = new Location(i, j);
                    var square = new Hint(location);
                    squares.Add(square);
                }
            }
            return squares;
        }

        public List<ISquare> Squares { get; private set; }
        public int Size { get; private set; }

        public static Board CreateEmptyBoard( int size)
        {
            if (size == 0)
            {
                return null;
            }
            return new Board(size);
        }

        public void SetMines(int numberOfMines)
        {
            var selectedSquares = Squares.OrderBy(x => _random.Next()).Take(numberOfMines);
            foreach (var item in selectedSquares)
            {
                var location = item.Location;
                var newMine = new Mine(location);
                Squares.Remove(item);
                Squares.Add(newMine);
            }
        }
        
        // public List<Mine> ToSquareList()
        // {
        //     var squares = new List<Mine>();
        //     var rowLength = Squares.GetLength(0);
        //     var columnLength = Squares.GetLength(1);
        //     for (int i = 0; i < rowLength; i++)
        //     {
        //         for (int j = 0; j < columnLength; j++)
        //         {
        //             squares.Add(Squares[i, j]);
        //         }
        //     }
        //
        //     return squares;
        // }

    }
}