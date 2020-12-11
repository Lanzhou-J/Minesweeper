namespace Minesweeper
{
    public class Board
    {
        private Square _empty = Square.Empty;
        private Square _mine = Square.Mine;
        public Board(int size)
        {
            Size = size;
            Squares = SetSquares();
        }

        private Square[][] SetSquares()
        {
            return new []{
                new[]{_mine}
            };
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