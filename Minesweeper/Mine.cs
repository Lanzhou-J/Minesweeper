namespace Minesweeper
{
    public class Mine : ISquare
    {
        public Mine(Location location)
        {
            IsRevealed = false;
            Location = location;
        }

        public bool IsRevealed { get; set; }

        public Location Location { get; set; }
        public int Value { get; set; }

        public string ToAString()
        {
            throw new System.NotImplementedException();
        }
    }
}