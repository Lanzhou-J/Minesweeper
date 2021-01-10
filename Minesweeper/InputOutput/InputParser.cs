using System;

namespace Minesweeper
{
    public static class InputParser
    {
       public static Location CreateLocationBasedOnInput(string input)
       {
            const string delimiter = ",";
            var delimiterIndex = GetDelimiterIndex(input, delimiter);
            var locationXInput = GetLocationXInputString(input, delimiterIndex);
            var locationYInput = GetLocationYInputString(input, delimiterIndex);
            var locationXValue = int.Parse(locationXInput);
            var locationYValue = int.Parse(locationYInput);
            var newLocation = new Location(locationXValue, locationYValue);
            return newLocation;
        }

       private static string GetLocationYInputString(string input, int delimiterIndex)
       {
           return input.Substring(delimiterIndex+1);
       }

       private static string GetLocationXInputString(string input, int delimiterIndex)
       {
           return input.Substring(0, delimiterIndex);
       }

       private static int GetDelimiterIndex(string input, string delimiter)
       {
           return input.IndexOf(delimiter, StringComparison.Ordinal);
       }
       
    }
}