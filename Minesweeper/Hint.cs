namespace Minesweeper
{
    public class Hint : ISquare
    {
        
        public Hint(Location location)
        {
            IsRevealed = false;
            Location = location;
            Value = 0;
        }

        public int Value { get; set; }

        public bool IsRevealed { get; set; }
        public Location Location { get; set; }
        public string ToAString()
        {
            throw new System.NotImplementedException();
        }
    }
}