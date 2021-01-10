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

           try
           {
               game.CreateBoard();
               game.Play();
           }
           catch (Exception ex)
           {
               Console.WriteLine();
               Console.WriteLine($"{ex.Message}");
               
               Environment.Exit(0);
           }
           
        }
    }
}