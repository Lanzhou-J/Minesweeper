namespace Minesweeper
{
    public class Game
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        public Board Board { get; set; }
        
        public Game(IInput input, IOutput output)
        {
            _input = input;
            _output = output;
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
            var difficultyInput = _input.Ask("Difficulty:");
            var difficulty = int.Parse(difficultyInput);
            return difficulty;
        }

        public void Play()
        {
            while (BoardIsNotRevealed())
            {
                var locationInput = _input.Ask("Please input a coordinate (e.g. 0,0):");
                var newLocation = CreateLocationBasedOnInput(locationInput);

                var isMine = Board.CheckMine(newLocation);
                
                if (isMine)
                {
                    Board.RevealAllSquares();
                }
                else
                {
                    Board.RevealOneSquare(newLocation);
                }
                DisplayBoard();
            }
        }

        private bool BoardIsNotRevealed()
        {
            return Board.IsRevealed != true;
        }

        private Location CreateLocationBasedOnInput(string input)
        {
            var xInput = input[0].ToString();
            var yInput = input[2].ToString();
            var xValue = int.Parse(xInput);
            var yValue = int.Parse(yInput);
            var newLocation = new Location(xValue, yValue);
            return newLocation;
        }

     

 
    }
}