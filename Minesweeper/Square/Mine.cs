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

        public string ToAString()
        {
            return IsRevealed ? "*" : ".";
        }
    }
}