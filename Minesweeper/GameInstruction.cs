namespace Minesweeper
{
    public static class GameInstruction
    {
        public static string DisplayCurrentBoardMessage()
        {
            return "Current Board:";
        }
        
        public static string InputDifficultyValueMessage()
        {
            return "Please input Difficulty Value (an integer larger than 0):";
        }
        
        public static string InputLocationValueMessage()
        {
            return "Please input a coordinate to reveal one square on the board (e.g. 0,0):";
        }
        
        public static string ResultMessage()
        {
            return "Result: ";
        }
        
        public static string GameOverMessage()
        {
            return "Game Over!";
        }
        
        public static string InputNotValidMessage()
        {
            return "Input is not valid.";
        }
        
        public static string WrongLocationMessage()
        {
            return "The coordinate is not on the board.";
        }
    }
}