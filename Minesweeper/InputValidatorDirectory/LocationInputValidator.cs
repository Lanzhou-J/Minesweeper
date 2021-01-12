using System.Text.RegularExpressions;

namespace Minesweeper
{
    public class LocationInputValidator: IValidator
    {
        
        private const string LocationInputPattern = "^[0-9]*,[0-9]*$";
        public bool IsValid(string input)
        {
            if (Regex.IsMatch(input, LocationInputPattern))
            {
                return true;
            }
            throw new InvalidInputException("Location input is invalid.");
        }
    }
}