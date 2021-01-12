using System.Text.RegularExpressions;

namespace Minesweeper
{
    public class DifficultyInputValidator:IValidator
    {
        private const string IntegerLargerThanZero = "^[1-9][0-9]*$";
        public bool IsValid(string input)
        {

            if (Regex.IsMatch(input, IntegerLargerThanZero))
            {
                return true;
            }
            throw new InvalidInputException("Difficulty value input is invalid.");

        }
    }
}