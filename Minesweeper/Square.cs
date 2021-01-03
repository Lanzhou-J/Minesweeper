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
        public void SetValue(int value)
        {
            Value = value;
        }

        public bool IsMine { get; set; }

        private bool IsRevealed { get; set; }

        private int Value { get; set; }
        public Location Location { get;}
        

        public override string ToString()
        {
            if (!IsRevealed) return ".";
            return IsMine ? "*" : Value.ToString();
        }
    }
}