using System.Data;

namespace Minesweeper
{
    public class Game
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly InputParser _inputParser;
        private readonly Player _player;
        private readonly IGenerateMines _minesGenerator;
        private readonly HintCalculator _hintsCalculator;
        public Board Board { get; private set; }
        
        public Game(IInput input, IOutput output, InputParser inputParser, Player player, IGenerateMines minesGenerator, HintCalculator hintsCalculator)
        {
            _input = input;
            _output = output;
            _inputParser = inputParser;
            _player = player;
            _minesGenerator = minesGenerator;
            _hintsCalculator = hintsCalculator;
        }

        public void SetUpBoard()
        {
            var difficultyValue = SetDifficultyValue();
            var size = difficultyValue;
            Board = Board.CreateEmptyBoard(size);
            var numberOfMines = difficultyValue;
            _minesGenerator.PlaceMines(numberOfMines, Board);
            _hintsCalculator.SetHints(Board);
            _output.Write(GameInstruction.DisplayCurrentBoardMessage());
            DisplayBoard();
        }
        
        private void DisplayBoard()
        {
            _output.Write(Board.ToString());
        }
        
        private int SetDifficultyValue()
        {
            var difficultyInput = _input.Ask(GameInstruction.InputDifficultyValueMessage());
            var difficultyValue = _inputParser.SetDifficultyLevel(difficultyInput);
            return difficultyValue;
        }

        public void Play()
        {
            while (BoardIsNotRevealed())
            {
                var locationInput = _input.Ask(GameInstruction.InputLocationValueMessage());
                var newLocation = _inputParser.CreateLocationBasedOnInput(locationInput);
        
                Board.RevealOneSquare(newLocation);
        
                if (Board.OneMineIsRevealed())
                {
                    _output.Write(GameInstruction.GameOverMessage());
                    Board.RevealAllSquares();
                    _player.State = PlayerState.Lose;
                    _output.Write(GameInstruction.PlayerStateMessage() + _player);
                }
                else if (Board.AllHintsAreRevealed())
                {
                    _output.Write(GameInstruction.GameOverMessage());
                    Board.RevealAllSquares();
                    _player.State = PlayerState.Win;
                    _output.Write(GameInstruction.PlayerStateMessage() + _player);
                }

                _output.Write(GameInstruction.DisplayCurrentBoardMessage());
                DisplayBoard();
            }
        }

        private bool BoardIsNotRevealed()
        {
            return !Board.IsRevealed;
        }

    }
}