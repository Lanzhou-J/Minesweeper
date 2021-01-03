namespace Minesweeper
{
    public class InputParser
    {
       public Location CreateLocationBasedOnInput(string input)
        {
            var xInput = input[0].ToString();
            var yInput = input[2].ToString();
            var xValue = int.Parse(xInput);
            var yValue = int.Parse(yInput);
            var newLocation = new Location(xValue, yValue);
            return newLocation;
        }

       public int SetDifficultyLevel(string input)
       {
           return int.Parse(input);
       }
    }
}