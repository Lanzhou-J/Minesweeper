using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;

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
            var mineLocations = DetermineMinesLocations();

            var hintLocations = DetermineHintsLocations(mineLocations);
            
            var hints = new List<Hint>();

            foreach (var item in hintLocations)
            {
                var neighbours = item.FindNeighboursFromLocations(Locations);
                var mineNeighbours = mineLocations.FindAll(x => neighbours.Contains(x));
                var mineNeighboursCount = mineNeighbours.Count;
                
                var hint = new Hint(item, mineNeighboursCount);
                hints.Add(hint);
            }
            return hints;
        }

        private List<Location> DetermineHintsLocations(List<Location> mineLocations)
        {
            return Locations.FindAll(x => !mineLocations.Contains(x));
        }

        private List<Location> DetermineMinesLocations()
        {
            return _mines.Select(mine => mine.Location).ToList();
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
        
        public ISquare FindSquareUsingLocationValue(int x, int y)
        {
            var square = Squares.Find(item => item.Location.X.Equals(x) && item.Location.Y.Equals(y));
            return square;
        }

    }
}