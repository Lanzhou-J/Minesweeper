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
           var board = Board.CreateEmptyBoard(2);
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
            var board = Board.CreateEmptyBoard(1);
            Assert.Equal(1, board.Size);
        }
        
        [Fact]
        public void CreateEmptyBoardShould_CreateASize2BoardWithSquaresLengthOf2_WhenInputIs2()
        {
            var board = Board.CreateEmptyBoard(2);
            Assert.Equal(2, board.Size);
        }

        [Fact]
        public void CreateHintsShould_ReturnNull_WhenThereIsOnly1MineSquare()
        {
            var board = Board.CreateEmptyBoard(1);
            board.PlaceMines(1);

            var hints = board.CreateHints();
            Assert.Null(hints);
        }
        
        [Fact]
        public void CreateHintsShould_ReturnAHintWithValue0_WhenThereIs0MineSquare()
        {
            var board = Board.CreateEmptyBoard(1);
            board.PlaceMines(0);

            var hints = board.CreateHints();
            Assert.Single(hints);
            Assert.Equal(0, hints.First().Value);
        }

        // [Fact]
        // public void CreateEmptyBoardShould_CreateABoardWith4Squares_WhenInputIs2()
        // {
        //     var board = Board.CreateEmptyBoard(2);
        //
        //     var squares = board.Squares;
        //
        //     Assert.Equal(4, squares.Count);
        // }
        //
        // [Fact]
        // public void CreateEmptyBoardShould_CreateABoardWithHintsOfValue0_WhenInputIs2()
        // {
        //     var board = Board.CreateEmptyBoard(2);
        //
        //     foreach (var item in board.Squares)
        //     {
        //         Assert.Equal(0, item.Value);
        //     }
        // }
        //
        //

    }
}