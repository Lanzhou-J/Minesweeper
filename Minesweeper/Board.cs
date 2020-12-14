namespace Minesweeper
{
    public class Board
    {
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
            
        }

    }
}