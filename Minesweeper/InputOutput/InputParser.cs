using System;

namespace Minesweeper
{
    public class InputParser
    {
       public Location CreateLocationBasedOnInput(string input)
       {
            const string delimiter = ",";
            var delimiterIndex = GetDelimiterIndex(input, delimiter);
            var locationXInput = input.Substring(0, delimiterIndex);
            var locationYInput = input.Substring(delimiterIndex+1);
            var locationXValue = int.Parse(locationXInput);
            var locationYValue = int.Parse(locationYInput);
            var newLocation = new Location(locationXValue, locationYValue);
            return newLocation;
        }

       private static int GetDelimiterIndex(string input, string delimiter)
       {
           return input.IndexOf(delimiter, StringComparison.Ordinal);
       }

       public int SetDifficultyLevel(string input)
       {
           return int.Parse(input);
       }
    }
}