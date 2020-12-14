namespace Minesweeper
{
    public class Game
    {
        private readonly IInput _input;
        private IOutput _output;
        private Board Board { get; set; }
        private readonly IGenerateMines _mineGenerator;

        public Game(IInput input, IOutput output, IGenerateMines mineGenerator)
        {
            _input = input;
            _output = output;
            _mineGenerator = mineGenerator;
        }

        public void Start()
        {
            var difficultyInput = _input.Ask("Difficulty:");
            var difficulty = int.Parse(difficultyInput);
            Board = Board.CreateEmptyBoard(difficulty);
            var mines = _mineGenerator.CreateMines(difficulty, Board.Locations);
            // Board.SetMines(difficulty);
        }
    }
}