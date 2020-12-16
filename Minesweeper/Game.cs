namespace Minesweeper
{
    public class Game
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        private Board Board { get; set; }
        

        public Game(IInput input, IOutput output)
        {
            _input = input;
            _output = output;
        }

        public void SetUp()
        {
            var difficulty = SetDifficultyValue();
            Board = Board.CreateEmptyBoardBasedOnSize(difficulty);
            Board.PlaceMines(difficulty);
            Board.PlaceHints();
            // Board.RevealSquares();
            DisplayBoard();
        }

        private void DisplayBoard()
        {
            _output.Write(Board.ToString());
        }

        private int SetDifficultyValue()
        {
            var difficultyInput = _input.Ask("Difficulty:");
            var difficulty = int.Parse(difficultyInput);
            return difficulty;
        }
    }
}