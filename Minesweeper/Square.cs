namespace Minesweeper
{
    public class Square
    {
        
        public bool IsMine { get; private set; }

        public bool IsRevealed { get; set; }

        public int Hint { get; set; }
        public Location Location { get;}
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

        public override string ToString()
        {
            if (!IsRevealed) return ".";
            return IsMine ? "*" : Hint.ToString();
        }
    }
}