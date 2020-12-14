using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class Board
    {
        private readonly Random _random = new Random();
        private Board(int size)
        {
            Size = size;
            Locations = CreateLocations();
        }
        
        private List<Location> CreateLocations()
        {
            var locations = new List<Location>();
            if (Size == 0)
            {
                locations = null;
            }
            else
            {
                for (var i = 0; i < Size; i++)
                {
                    for (var j = 0; j < Size; j++)
                    {
                        var location = new Location(i, j);
                        locations.Add(location);
                    }
                }
            }
            return locations;
        }

        public static Board CreateEmptyBoard(int size)
        {
            return new Board(size);
        }

        private List<ISquare> SetSquares()
        {
            var squares = new List<ISquare>();
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    var location = new Location(i, j);
                    var square = new Hint(location);
                    squares.Add(square);
                }
            }
            return squares;
        }

        public List<ISquare> Squares { get; private set; } = new List<ISquare>();
        public List<Location> Locations { get; private set; }
        public int Size { get; private set; }



        public void CreateMines(int numberOfMines)
        {
            var selectedLocations = Locations.OrderBy(x => _random.Next()).Take(numberOfMines);
            foreach (var item in selectedLocations)
            {
                var newMine = new Mine(item);
                Squares.Add(newMine);
            }
        }

    }
}