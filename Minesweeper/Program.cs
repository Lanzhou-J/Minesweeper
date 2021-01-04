namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
           var input = new ConsoleInput();
           var output = new ConsoleOutput();
           var inputParser = new InputParser();
           var player = new Player();
           var minesGenerator = new RandomMinesGenerator();
           var hintsCalculator = new HintCalculator();
           var game = new Game(input, output, inputParser, player, minesGenerator, hintsCalculator);
           
           game.SetUpBoard();
           game.Play();
        }
    }
}