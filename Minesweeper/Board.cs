using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class Board
    {
        public int Size { get; private set; }
        public List<ISquare> Squares { get; set; } = new List<ISquare>();
        public List<Location> Locations { get; private set; }
        private IGenerateMines MineGenerator { get; set; }
        private List<Mine> _mines;
        private readonly Random _random = new Random();
        private Board(int size, IGenerateMines mineGenerator)
        {
            MineGenerator = mineGenerator;
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
                AddEachNewLocationToLocations(locations);
            }
            return locations;
        }

        private void AddEachNewLocationToLocations(List<Location> locations)
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

        public static Board CreateEmptyBoardBasedOnSize(int size)
        {
            return new Board(size, new RandomMinesGenerator());
        }
        
        public static Board CreateEmptyBoardBasedOnSize(int size, IGenerateMines minesGenerator)
        {
            return new Board(size, minesGenerator);
        }
        
        public void PlaceMines(int number)
        {
            _mines = MineGenerator.CreateMines(number, Locations);
            Squares.AddRange(_mines);
        }



        public void PlaceHints()
        {
            var hints = CreateHints();
            Squares.AddRange(hints);
        }
        
        public List<Hint> CreateHints()
        {
            RemoveMinesLocationsFromLocationsList();
            
            var hints = new List<Hint>();

            foreach (var item in Locations)
            {
                var neighbourMineCount = 0;
                if (Squares.Count>0)
                {
                    neighbourMineCount = 1;
                }
                var hint = new Hint(item, neighbourMineCount);
                hints.Add(hint);
            }
            return hints;
        }
        
        private void RemoveMinesLocationsFromLocationsList()
        {
            foreach (var mine in _mines)
            {
                Locations.Remove(mine.Location);
            }
        }

        public void RevealSquares()
        {
            foreach (var item in Squares.Where(item => item.IsRevealed == false))
            {
                item.IsRevealed = true;
            }
        }

        public override string ToString()
        {
            var message = "";
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    message += FindSquareUsingLocationValue(i,j).ToAString();
                    message += " ";
                }

                message += "\n";
            }

            return message;
        }
        
        private ISquare FindSquareUsingLocationValue(int x, int y)
        {
            var square = Squares.Find(item => item.Location.X.Equals(x) && item.Location.Y.Equals(y));
            return square;
        }

        //     var hints = new List<Hint>();
        //     var value = 0;
        //     foreach (var item in Locations)
        //     {
        //         var neighboursLocations = item.GetNeighboursLocations();
        //         value += (from location in neighboursLocations from mine in _mines where mine.Location.X == location.X && mine.Location.Y == location.Y select location).Count();
        //         var hint = new Hint(item, value);
        //         hints.Add(hint);
        //     }
        //     
        //     return hints;
        // }

    }
}