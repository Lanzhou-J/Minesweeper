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

        private Mine[,] SetSquares()
        {
            var index = 1;
            var squares = new Mine[Size,Size];
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    squares[i,j] = new Mine(index);
                    index++;
                }
            }
            return squares;
        }

        public Mine[,] Squares { get; private set; }
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
            var squares = ToSquareList();
            var selectedSquares = squares.OrderBy(x => _random.Next()).Take(numberOfMines);
            foreach (var item in selectedSquares)
            {
                item.IsMine = true;
            }
        }
        
        public List<Mine> ToSquareList()
        {
            var squares = new List<Mine>();
            var rowLength = Squares.GetLength(0);
            var columnLength = Squares.GetLength(1);
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    squares.Add(Squares[i, j]);
                }
            }

            return squares;
        }

    }
}