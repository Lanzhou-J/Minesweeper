using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class RandomMinesGenerator : IGenerateMines
    {
        
        private readonly Random _random = new Random();
        
        public void PlaceMines(int number, Board board)
        {
            var selectedSquares = board.Squares.OrderBy(x => _random.Next()).Take(number);
            foreach (var item in selectedSquares)
            {
                item.SetMine();
            }
        }
    }
}