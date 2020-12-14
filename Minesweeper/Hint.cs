namespace Minesweeper
{
    public class Hint : ISquare
    {
        public bool IsRevealed { get; set; }
        public Location Location { get; set; }
        public string ToAString()
        {
            throw new System.NotImplementedException();
        }
    }
}