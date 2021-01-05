using System.Data;

namespace Minesweeper
{
    public class Game
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly InputParser _inputParser;
        private readonly IGenerateMines _minesGenerator;
        private readonly HintCalculator _hintsCalculator;
        private GameState _state;
        public Board Board { get; private set; }
        
        public Game(IInput input, IOutput output, InputParser inputParser, IGenerateMines minesGenerator, HintCalculator hintsCalculator)
        {
            _input = input;
            _output = output;
            _inputParser = inputParser;
            _minesGenerator = minesGenerator;
            _hintsCalculator = hintsCalculator;
            _state = GameState.Unknown;
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
        
                if (Rule.IsLosingCondition(Board))
                {
                    _output.Write(GameInstruction.GameOverMessage());
                    Board.RevealAllSquares();
                    _state = GameState.Lose;
                    _output.Write(GameInstruction.ResultMessage() + _state);
                }
                else if (Rule.IsWinningCondition(Board))
                {
                    _output.Write(GameInstruction.GameOverMessage());
                    Board.RevealAllSquares();
                    _state = GameState.Win;
                    _output.Write(GameInstruction.ResultMessage() + _state);
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