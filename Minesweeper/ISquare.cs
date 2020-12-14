namespace Minesweeper
{
    public interface ISquare
    {
        bool IsRevealed { get; set; }
        Location Location { get; set; }
        int Value { get; set; }

        string ToAString();
        


    }
}