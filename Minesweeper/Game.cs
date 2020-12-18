using System.Data;

namespace Minesweeper
{
    public class Game
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly InputParser _inputParser;
        private Player _player;
        public Board Board { get; set; }
        
        public Game(IInput input, IOutput output, InputParser inputParser, Player player)
        {
            _input = input;
            _output = output;
            _inputParser = inputParser;
            _player = player;
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

                var isMine = Board.CheckMine(newLocation);
                
                if (isMine)
                {
                    Board.RevealAllSquares();
                    _player.State = PlayerState.Lose;
                    _output.Write("Player is lost!");
                }
                else
                {
                    Board.RevealOneSquare(newLocation);
                    
                    if (Board.AllHintsAreRevealed())
                    {
                        _player.State = PlayerState.Win;
                        _output.Write("Player wins!!");
                        Board.RevealAllSquares();
                    }
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