using System;
using System.Collections.Generic;
using System.Linq;
using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class BoardTest
    { 
        [Theory]
       [InlineData(1,1,3)]
       [InlineData(0,0,0)]
       [InlineData(0,1,1)]
       [InlineData(1,0,2)]
       public void CreateEmptyBoardShould_CreateCorrectLocations_AccordingToTheSizeOfTheBoard(int expectedX, int expectedY, int index)
       {
           var board = Board.CreateEmptyBoardBasedOnSize(2);
           var locations = board.Locations;
           var location = locations[index];
           var locationX = location.X;
           var locationY = location.Y;
            
           Assert.Equal(expectedX, locationX);
           Assert.Equal(expectedY, locationY);
       }
        
        [Fact]
        public void CreateEmptyBoardShould_CreateASize1Board_WhenInputIs1()
        {
            var board = Board.CreateEmptyBoardBasedOnSize(1);
            Assert.Equal(1, board.Size);
        }
        
        [Fact]
        public void CreateEmptyBoardShould_CreateASize2BoardWithSquaresLengthOf2_WhenInputIs2()
        {
            var board = Board.CreateEmptyBoardBasedOnSize(2);
            Assert.Equal(2, board.Size);
        }

        [Fact]
        public void CreateHintsShould_ReturnEmptyList_WhenThereIsOnly1MineSquare()
        {
            var board = Board.CreateEmptyBoardBasedOnSize(1);
            board.PlaceMines(1);

            var hints = board.CreateHints();
            Assert.Empty(hints);
        }
        
        [Fact]
        public void CreateHintsShould_ReturnAHintWithValue0_WhenThereIs0MineSquare()
        {
            var board = Board.CreateEmptyBoardBasedOnSize(1);
            board.PlaceMines(0);

            var hints = board.CreateHints();
            Assert.Single(hints);
            Assert.Equal(0, hints.First().Value);
        }
        
        [Fact]
        public void CreateHintsShould_Return4HintsWithValue0_WhenThereIsNoMine_InASize2Board()
        {
            var board = Board.CreateEmptyBoardBasedOnSize(2);
            board.PlaceMines(0);

            var hints = board.CreateHints();
            Assert.Equal(4, hints.Count);
            foreach (var item in hints)
            {
                Assert.Equal(0, item.Value);
            }
        }
        
        [Fact]
        public void CreateHintsShould_Return3HintsWithValue1_WhenThereIs1Mine_InASize2Board()
        {
            var board = Board.CreateEmptyBoardBasedOnSize(2);
            board.PlaceMines(1);

            var hints = board.CreateHints();
            Assert.Equal(3, hints.Count);
            foreach (var item in hints)
            {
                Assert.Equal(1, item.Value);
            }
        }

    }
}