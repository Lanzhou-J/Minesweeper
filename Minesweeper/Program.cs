using System;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
           var input = new ConsoleInput();
           var output = new ConsoleOutput();
           var minesGenerator = new RandomMinesGenerator();
           var game = new Game(input, output, minesGenerator);
           
               game.CreateBoard();
               game.Play();

           
        }
    }
}