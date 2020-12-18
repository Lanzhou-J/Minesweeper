namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
           var input = new ConsoleInput();
           var output = new ConsoleOutput();
           var inputParser = new InputParser();
           var game = new Game(input, output, inputParser);
           
           game.SetUpBoard();
           game.Play();
        }
    }
}