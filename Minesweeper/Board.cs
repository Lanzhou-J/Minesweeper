namespace Minesweeper
{
    public class Board
    {
        private const Square Empty = Square.Empty;

        private Board(int size)
        {
            Size = size;
            Squares = SetSquares();
        }

        private Square[,] SetSquares()
        {
            var squares = new Square[Size,Size];
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    squares[i,j] = Empty;
                }
            }
            return squares;
        }

        public Square[,] Squares { get; private set; }
        public int Size { get; private set; }

        public static Board CreateBoard( int size)
        {
            if (size == 0)
            {
                return null;
            }
            return new Board(size);
        }
    }
}