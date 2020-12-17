namespace Minesweeper
{
    public interface ISquare
    {
        int Value { get; set; }
        bool IsRevealed { get; set; }
        Location Location { get; set; }

        string ToAString();
        
    }
}