using System;

namespace Minesweeper
{
    public class ConsoleInput : IInput
    {
        public string Ask(string question)
        {
            // try
            // {
                Console.WriteLine(question);
                return Console.ReadLine();
            // }
            // catch (Exception e)
            // {
            //     throw new FailToCollectInputException("Something goes wrong when collecting user input.", e);
            // }
            
        }
    }
}