using System;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
           var input = new ConsoleInput();
           var output = new ConsoleOutput();
           
           var game = new Game(input, output);
           
           game.Start();
        }
    }
}