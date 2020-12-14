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

        private Square[,] SetSquares()
        {
            var index = 1;
            var squares = new Square[Size,Size];
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    squares[i,j] = new Square(index);
                    index++;
                }
            }
            return squares;
        }

        public Square[,] Squares { get; private set; }
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
            var selectedSquares = squares.OrderBy(x => _random.Next()).Take(5);
            foreach (var item in selectedSquares)
            {
                item.IsMine = true;
            }
        }
        
        public List<Square> ToSquareList()
        {
            var squares = new List<Square>();
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