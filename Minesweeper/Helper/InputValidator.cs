using System.Text.RegularExpressions;

namespace Minesweeper
{
    public static class InputValidator
    {
        private const string IntegerLargerThanZero = "^[1-9][0-9]*$";
        private const string LocationInputPattern = "^[0-9]*,[0-9]*$";
        public static bool IsValidDifficultyInput(string input)
        {
            return Regex.IsMatch(input, IntegerLargerThanZero);
        }

        public static bool IsValidLocationInput(string input)
        {
            
            return Regex.IsMatch(input, LocationInputPattern);
        }
    }
}