namespace Minesweeper
{
    public class Board
    {
        private SquareState _empty = SquareState.Empty;
        private SquareState _mine = SquareState.Mine;
        public Board(int size)
        {
            Size = size;
            Squares = SetSquares();
        }

        private SquareState[][] SetSquares()
        {
            return new []{
                new[]{_empty}
            };
        }

        public SquareState[][] Squares { get; private set; }
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