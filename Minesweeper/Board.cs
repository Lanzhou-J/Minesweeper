namespace Minesweeper
{
    public class Board
    {
        public Board(int size)
        {
            Size = size;
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