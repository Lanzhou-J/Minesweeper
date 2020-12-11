namespace Minesweeper
{
    public class Board
    {
        private Square _empty = Square.Empty;
        private Square _mine = Square.Mine;

        private Board(int size)
        {
            Size = size;
            Squares = SetSquares();
        }

        private Square[][] SetSquares()
        {
            var squares = new Square[Size][];
            for (int i = 0; i < Size; i++)
            {
                squares[i] = new Square[Size];
                for (int j = 0; j < Size; j++)
                {
                    squares[i][j] = _empty;
                }
            }
            return squares;
        }

        public Square[][] Squares { get; private set; }
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