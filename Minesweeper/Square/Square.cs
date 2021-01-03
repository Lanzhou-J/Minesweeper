namespace Minesweeper
{
    public class Square
    {
        public Square(Location location)
        {
            IsRevealed = false;
            Location = location;
            IsMine = false;
            
        }

        public void Reveal()
        {
            IsRevealed = true;
        }

        public void SetMine()
        {
            IsMine = true;
        }

        protected bool IsMine { get; private set; }

        protected bool IsRevealed { get; private set; }
        protected Location Location { get;}

        public override string ToString()
        {
            if (IsMine && IsRevealed)
            {
                return "*";
            }
            return ".";
        }
    }
}