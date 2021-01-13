using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class RandomMinesGenerator : IGenerateMines
    {
        
        private readonly Random _random = new Random();
        
        public void PlaceMines(int numberOfMines, Board board)
        {
            var selectedSquares = RandomlySelectSquares(numberOfMines, board);
            PlaceMineOnEachOfTheSelectedSquares(selectedSquares);
        }

        private static void PlaceMineOnEachOfTheSelectedSquares(IEnumerable<Square> selectedSquares)
        {
            foreach (var square in selectedSquares)
            {
                square.SetMine();
            }
        }

        private IEnumerable<Square> RandomlySelectSquares(int number, Board board)
        {
            return board.Squares.OrderBy(x => _random.Next()).Take(number);
        }
    }
}