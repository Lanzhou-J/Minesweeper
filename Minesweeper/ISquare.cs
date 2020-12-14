namespace Minesweeper
{
    public interface ISquare
    {
        bool IsRevealed { get; set; }
        Location Location { get; set; }

        string ToAString();


    }
}