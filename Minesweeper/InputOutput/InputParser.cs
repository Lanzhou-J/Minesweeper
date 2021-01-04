using System;

namespace Minesweeper
{
    public class InputParser
    {
       public Location CreateLocationBasedOnInput(string input)
       {
            const string delimiter = ",";
            var delimiterIndex = input.IndexOf(delimiter, StringComparison.Ordinal);
            var xInput = input.Substring(0, delimiterIndex);
            var yInput = input.Substring(delimiterIndex+1);
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