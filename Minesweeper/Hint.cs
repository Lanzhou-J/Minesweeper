namespace Minesweeper
{
    public class Hint : ISquare
    {
        
        public Hint(Location location, int value)
        {
            IsRevealed = false;
            Location = location;
            Value = value;
        }

        public int Value { get; set; }

        public bool IsRevealed { get; set; }
        public Location Location { get; set; }
        public string ToAString()
        {
            if (IsRevealed)
            {
                return Value.ToString();
            }
            return ".";
        }
    }
}