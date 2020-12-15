namespace Minesweeper
{
    public class Game
    {
        private readonly IInput _input;
        private IOutput _output;
        private Board Board { get; set; }
        

        public Game(IInput input, IOutput output)
        {
            _input = input;
            _output = output;
        }

        public void Start()
        {
            var difficultyInput = _input.Ask("Difficulty:");
            var difficulty = int.Parse(difficultyInput);
            Board = Board.CreateEmptyBoardBasedOnSize(difficulty);
            Board.PlaceMines(difficulty);
            
        }
    }
}