using System;

namespace Minesweeper
{
    public class Game
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly IGenerateMines _minesGenerator;
        public GameState State { get; private set; }
        public Board Board { get; private set; }
        
        public Game(IInput input, IOutput output, IGenerateMines minesGenerator)
        {
            _input = input;
            _output = output;
            _minesGenerator = minesGenerator;
            State = GameState.Unknown;
        }

        public void CreateBoard()
        {
            var difficultyValue = SetDifficultyValue();
            var size = difficultyValue;
            Board = Board.CreateEmptyBoard(size);
            var numberOfMines = difficultyValue;
            _minesGenerator.PlaceMines(numberOfMines, Board);
            HintGenerator.SetHints(Board);
            _output.Write(GameInstruction.DisplayCurrentBoardMessage);
            DisplayBoard();
        }
        
        private void DisplayBoard()
        {
            _output.Write(Board.ToString());
        }
        
        private int SetDifficultyValue()
        {
            var difficultyInput = "";
            var isInputValid = false;
            while (isInputValid == false)
            {
                try
                {
                    difficultyInput = _input.Ask(GameInstruction.InputDifficultyValueMessage);
                    var validator = new DifficultyInputValidator();
                    if (validator.IsValid(difficultyInput))
                    {
                        isInputValid = true;
                    }
                }
                catch (InvalidInputException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
            var difficultyValue = int.Parse(difficultyInput);
            return difficultyValue;
        }

        public void Play()
        {
            while (BoardIsNotRevealed())
            {
                var newLocation = CreateLocationBasedOnInput();

                RevealTheSquareIfLocationIsOnBoard(newLocation);

                if (Rule.IsLosingCondition(Board))
                {
                    _output.Write(GameInstruction.GameOverMessage);
                    Board.RevealAllSquares();
                    State = GameState.Lose;
                    _output.Write(GameInstruction.ResultMessage + State);
                }
                else if (Rule.IsWinningCondition(Board))
                {
                    _output.Write(GameInstruction.GameOverMessage);
                    Board.RevealAllSquares();
                    State = GameState.Win;
                    _output.Write(GameInstruction.ResultMessage + State);
                }

                _output.Write(GameInstruction.DisplayCurrentBoardMessage);
                DisplayBoard();
            }
        }

        private void RevealTheSquareIfLocationIsOnBoard(Location newLocation)
        {
            if (Board.HasLocation(newLocation))
            {
                Board.RevealOneSquare(newLocation);
            }
            else
            {
                _output.Write(GameInstruction.WrongLocationMessage);
            }
        }

        private Location CreateLocationBasedOnInput()
        {
            var locationInput = _input.Ask(GameInstruction.InputLocationValueMessage);
            while (LocationInputIsNotValid(locationInput))
            {
                // _output.Write(GameInstruction.InputNotValidMessage);
                locationInput = _input.Ask(GameInstruction.InputLocationValueMessage);
            }

            var newLocation = InputParser.CreateLocationBasedOnInput(locationInput);
            return newLocation;
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