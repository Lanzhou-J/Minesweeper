namespace Minesweeper
{
    public class Square
    {
        public Square()
        {
            IsMine = false;
            Hint = 0;
        }

        public bool IsMine { get; private set; }
        public int Hint { get; private set; }

    }
}