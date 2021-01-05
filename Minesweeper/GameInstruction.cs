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
        
        public static string PlayerStateMessage()
        {
            return "Result: ";
        }
        
        public static string GameOverMessage()
        {
            return "Game Over!";
        }
    }
}