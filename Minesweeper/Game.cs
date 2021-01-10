using System.Data;

namespace Minesweeper
{
    public class Game
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly InputParser _inputParser;
        private readonly IGenerateMines _minesGenerator;
        private readonly HintGenerator _hintsGenerator;
        public GameState State { get; private set; }
        public Board Board { get; private set; }
        
        public Game(IInput input, IOutput output, InputParser inputParser, IGenerateMines minesGenerator, HintGenerator hintsGenerator)
        {
            _input = input;
            _output = output;
            _inputParser = inputParser;
            _minesGenerator = minesGenerator;
            _hintsGenerator = hintsGenerator;
            State = GameState.Unknown;
        }

        public void CreateBoard()
        {
            var difficultyValue = SetDifficultyValue();
            var size = difficultyValue;
            Board = Board.CreateEmptyBoard(size);
            var numberOfMines = difficultyValue;
            _minesGenerator.PlaceMines(numberOfMines, Board);
            _hintsGenerator.SetHints(Board);
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
            while (DifficultyInputIsNotValid(difficultyInput))
            {
                _output.Write(GameInstruction.InputNotValidMessage());
                difficultyInput = _input.Ask(GameInstruction.InputDifficultyValueMessage());
            }
            
            var difficultyValue = int.Parse(difficultyInput);
            return difficultyValue;
        }

        private static bool DifficultyInputIsNotValid(string difficultyInput)
        {
            return !InputValidator.IsValidDifficultyInput(difficultyInput);
        }

        public void Play()
        {
            while (BoardIsNotRevealed())
            {
                var locationInput = _input.Ask(GameInstruction.InputLocationValueMessage());
                while (LocationInputIsNotValid(locationInput))
                {
                    _output.Write(GameInstruction.InputNotValidMessage());
                    locationInput = _input.Ask(GameInstruction.InputLocationValueMessage());
                }
                var newLocation = _inputParser.CreateLocationBasedOnInput(locationInput);

                if (Board.HasLocation(newLocation))
                {
                    Board.RevealOneSquare(newLocation);
                }
                else
                {
                    _output.Write(GameInstruction.WrongLocationMessage());
                }

                if (Rule.IsLosingCondition(Board))
                {
                    _output.Write(GameInstruction.GameOverMessage());
                    Board.RevealAllSquares();
                    State = GameState.Lose;
                    _output.Write(GameInstruction.ResultMessage() + State);
                }
                else if (Rule.IsWinningCondition(Board))
                {
                    _output.Write(GameInstruction.GameOverMessage());
                    Board.RevealAllSquares();
                    State = GameState.Win;
                    _output.Write(GameInstruction.ResultMessage() + State);
                }

                _output.Write(GameInstruction.DisplayCurrentBoardMessage());
                DisplayBoard();
            }
        }

        private static bool LocationInputIsNotValid(string locationInput)
        {
            return !InputValidator.IsValidLocationInput(locationInput);
        }

        private bool BoardIsNotRevealed()
        {
            return !Board.IsRevealed;
        }

    }
}