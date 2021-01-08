namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
           var input = new ConsoleInput();
           var output = new ConsoleOutput();
           var inputParser = new InputParser();
           var minesGenerator = new RandomMinesGenerator();
           var hintsCalculator = new HintGenerator();
           var game = new Game(input, output, inputParser, minesGenerator, hintsCalculator);
           
           game.CreateBoard();
           game.Play();
        }
    }
}