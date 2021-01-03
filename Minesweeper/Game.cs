using System.Data;

namespace Minesweeper
{
    public class Game
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly InputParser _inputParser;
        private Player _player;
        private readonly IGenerateMines _minesGenerator;
        public Board Board { get; set; }
        
        public Game(IInput input, IOutput output, InputParser inputParser, Player player, IGenerateMines minesGenerator)
        {
            _input = input;
            _output = output;
            _inputParser = inputParser;
            _player = player;
            _minesGenerator = minesGenerator;
        }

        public void SetUpBoard()
        {
            var difficulty = SetDifficultyValue();
            Board = Board.CreateEmptyBoardBasedOnSize(difficulty, _minesGenerator);
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
            var difficultyInput = _input.Ask("Difficulty (a number larger than 0):");
            var difficulty = _inputParser.SetDifficultyLevel(difficultyInput);
            return difficulty;
        }

        public void Play()
        {
            while (BoardIsNotRevealed())
            {
                var locationInput = _input.Ask("Please input a coordinate (e.g. 0,0):");
                var newLocation = _inputParser.CreateLocationBasedOnInput(locationInput);

                Board.RevealOneSquare(newLocation);

                if (Board.OneMineIsRevealed())
                {
                    Board.RevealAllSquares();
                    _player.State = PlayerState.Loser;
                    _output.Write("You are " + _player.ToString());
                }
                else if (Board.AllHintsAreRevealed())
                {
                    Board.RevealAllSquares();
                    _player.State = PlayerState.Winner;
                    _output.Write("You are " + _player.ToString());
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