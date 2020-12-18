namespace Minesweeper
{
    public class Game
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly InputParser _inputParser;
        public Board Board { get; set; }
        
        public Game(IInput input, IOutput output, InputParser inputParser)
        {
            _input = input;
            _output = output;
            _inputParser = inputParser;
        }

        public void SetUpBoard()
        {
            var difficulty = SetDifficultyValue();
            Board = Board.CreateEmptyBoardBasedOnSize(difficulty);
            Board.PlaceMines(difficulty);
            Board.PlaceHints();
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

        public void Play()
        {
            while (BoardIsNotRevealed())
            {
                var locationInput = _input.Ask("Please input a coordinate (e.g. 0,0):");
                var newLocation = _inputParser.CreateLocationBasedOnInput(locationInput);

                var isMine = Board.CheckMine(newLocation);
                
                if (isMine)
                {
                    Board.RevealAllSquares();
                }
                else
                {
                    Board.RevealOneSquare(newLocation);
                }
                DisplayBoard();
            }
        }

        private bool BoardIsNotRevealed()
        {
            return Board.IsRevealed != true;
        }

    }
}