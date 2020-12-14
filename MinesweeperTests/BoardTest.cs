using System;
using System.Collections.Generic;
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
        public void CreateEmptyBoardShould_CreateABoardWithAHint_WhenInputIs1()
        {
            var board = Board.CreateEmptyBoard(1);

            var squares = board.Squares;

            Assert.Single(squares);
        }
        
        [Fact]
        public void CreateEmptyBoardShould_CreateASize2BoardWithSquaresLengthOf2_WhenInputIs2()
        {
            var board = Board.CreateEmptyBoard(2);
            Assert.Equal(2, board.Size);
            Assert.Equal(2, board.Squares.GetLength(0));
            Assert.Equal(2, board.Squares.GetLength(1));
        }
        
        [Fact]
        public void CreateEmptyBoardShould_CreateABoardWithSquaresNotMine_WhenInputIs2()
        {
            var board = Board.CreateEmptyBoard(2);

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    var square = board.Squares[i, j];
                    Assert.False(square.IsMine);
                }
            }
        }
        
        [Theory]
        [InlineData(1,1,4)]
        [InlineData(0,0,1)]
        [InlineData(0,1,2)]
        [InlineData(1,0,3)]
        public void CreateEmptyBoardShould_CreateABoardWithSquaresThatHaveCorrectIndexValues(int x, int y, int expectedIndex)
        {
            var board = Board.CreateEmptyBoard(2);
            var index = board.Squares[x, y].Index;
            Assert.Equal(expectedIndex, index);
        }

        [Fact]
        public void SetMinesShould_Change1SquareToMine_WhenInputIs1()
        {
            var board = Board.CreateEmptyBoard(1);
            board.SetMines(1);
            var squares = board.ToSquareList();
            var mines = squares.FindAll(x => x.IsMine);
            Assert.Single(mines);
        }
        
        [Fact]
        public void SetMinesShould_Change5SquareToMine_WhenInputIs5()
        {
            var board = Board.CreateEmptyBoard(5);
            board.SetMines(5);
            var squares = board.ToSquareList();
            var mines = squares.FindAll(x => x.IsMine);
            Assert.Equal(5, mines.Count);
        }
        
        [Fact]
        public void SetMinesShould_Change5SquareToMine_WhenInputIs10()
        {
            var board = Board.CreateEmptyBoard(10);
            board.SetMines(10);
            var squares = board.ToSquareList();
            var mines = squares.FindAll(x => x.IsMine);
            Assert.Equal(10, mines.Count);
        }


    }
}