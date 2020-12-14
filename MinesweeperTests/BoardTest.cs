using System;
using System.Collections.Generic;
using System.Linq;
using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class BoardTest
    {
        [Fact]
        public void CreateEmptyBoardShould_ReturnNull_WhenInputIs0()
        {
            var board = Board.CreateEmptyBoard(0);
            Assert.Null(board);
        }
        
        [Fact]
        public void CreateEmptyBoardShould_CreateASize1Board_WhenInputIs1()
        {
            var board = Board.CreateEmptyBoard(1);
            Assert.Equal(1, board.Size);
        }
        
        [Fact]
        public void CreateEmptyBoardShould_CreateABoardWithOneSquare_WhenInputIs1()
        {
            var board = Board.CreateEmptyBoard(1);

            var squares = board.Squares;

            Assert.Single(squares);
        }
        
        [Fact]
        public void CreateEmptyBoardShould_CreateABoardWithAHintOfValue0_WhenInputIs1()
        {
            var board = Board.CreateEmptyBoard(1);

            var squares = board.Squares;

            var hint = squares.First();

            Assert.Equal(0, hint.Value);
        }
        
        [Fact]
        public void CreateEmptyBoardShould_CreateASize2BoardWithSquaresLengthOf2_WhenInputIs2()
        {
            var board = Board.CreateEmptyBoard(2);
            Assert.Equal(2, board.Size);
        }
        
        [Fact]
        public void CreateEmptyBoardShould_CreateABoardWith4Squares_WhenInputIs2()
        {
            var board = Board.CreateEmptyBoard(2);

            var squares = board.Squares;

            Assert.Equal(4, squares.Count);
        }
        
        [Fact]
        public void CreateEmptyBoardShould_CreateABoardWithHintsOfValue0_WhenInputIs2()
        {
            var board = Board.CreateEmptyBoard(2);

            foreach (var item in board.Squares)
            {
                Assert.Equal(0, item.Value);
            }
        }
        
        [Theory]
        [InlineData(1,1,3)]
        [InlineData(0,0,0)]
        [InlineData(0,1,1)]
        [InlineData(1,0,2)]
        public void CreateEmptyBoardShould_CreateABoardWithSquaresThatHaveCorrectLocations(int expectedX, int expectedY, int index)
        {
            var board = Board.CreateEmptyBoard(2);
            var square = board.Squares[index];
            var locationX = square.Location.X;
            var locationY = square.Location.Y;
            
            Assert.Equal(expectedX, locationX);
            Assert.Equal(expectedY, locationY);
        }
        
        [Fact]
        public void SetMinesShould_Change1SquareToMine_WhenInputIs1()
        {
            var board = Board.CreateEmptyBoard(1);
            board.SetMines(1);
            var squares = board.Squares;
            var mines = squares.FindAll(x => x.GetType() == typeof(Mine));
            Assert.Single(mines);
        }
        //
        // [Fact]
        // public void SetMinesShould_Change5SquareToMine_WhenInputIs5()
        // {
        //     var board = Board.CreateEmptyBoard(5);
        //     board.SetMines(5);
        //     var squares = board.ToSquareList();
        //     var mines = squares.FindAll(x => x.IsMine);
        //     Assert.Equal(5, mines.Count);
        // }
        //
        // [Fact]
        // public void SetMinesShould_Change5SquareToMine_WhenInputIs10()
        // {
        //     var board = Board.CreateEmptyBoard(10);
        //     board.SetMines(10);
        //     var squares = board.ToSquareList();
        //     var mines = squares.FindAll(x => x.IsMine);
        //     Assert.Equal(10, mines.Count);
        // }


    }
}