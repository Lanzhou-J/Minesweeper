namespace Minesweeper
{
    public class Game
    {
        private IInput _input;
        private IOutput _output;
        public Board Board { get; private set; }

        public Game(IInput input, IOutput output)
        {
            _input = input;
            _output = output;
        }

        public void Start()
        {
            var difficultyInput = _input.Ask("Difficulty:");
            var difficulty = int.Parse(difficultyInput);
            Board = Board.CreateEmptyBoard(difficulty);
        }
    }
}