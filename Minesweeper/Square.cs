namespace Minesweeper
{
    public class Square
    {
        public Square(int index)
        {
            IsMine = false;
            Hint = 0;
            Index = index;
        }

        public bool IsMine { get; set; }
        public int Hint { get; set; }

        public int Index { get; set; }

    }
}