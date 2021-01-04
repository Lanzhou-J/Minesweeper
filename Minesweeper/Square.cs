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

        public void IncrementHint()
        {
            Hint += 1;
        }

        public bool IsMine { get; private set; }

        public bool IsRevealed { get; set; }

        public int Hint { get; private set; }
        public Location Location { get;}


        public override string ToString()
        {
            if (!IsRevealed) return ".";
            return IsMine ? "*" : Hint.ToString();
        }
    }
}