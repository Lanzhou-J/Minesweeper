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

        private bool BoardIsNotRevealed()
        {
            return !Board.IsRevealed;
        }

    }
}