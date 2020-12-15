using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class Board
    {
        private List<ISquare> Squares { get; set; } = new List<ISquare>();
        public List<Location> Locations { get; private set; }
        public int Size { get; private set; }
        private readonly IGenerateMines _mineGenerator;
        private List<Mine> _mines;
        private readonly Random _random = new Random();
        private Board(int size, IGenerateMines mineGenerator)
        {
            _mineGenerator = mineGenerator;
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
            return new Board(size, new RandomMinesGenerator());
        }
        
        public void PlaceMines(int number)
        {
            _mines = _mineGenerator.CreateMines(number, Locations);
            Squares.AddRange(_mines);
        }

        public void AddHintsToSquares()
        {
            var hints = CreateHints();
            Squares.AddRange(hints);
        }

        private List<Hint> CreateHints()
        {
            var hints = new List<Hint>();
            var value = 0;
            foreach (var item in Locations)
            {
                var neighboursLocations = item.GetNeighboursLocations();
                value += (from location in neighboursLocations from mine in _mines where mine.Location.X == location.X && mine.Location.Y == location.Y select location).Count();
                var hint = new Hint(item, value);
                hints.Add(hint);
            }
            
            return hints;
        }

    }
}