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
            Assert.Equal(1, board.Squares.GetLength(0));
            Assert.Equal(1, board.Squares.GetLength(1));
        }
        
        [Fact]
        public void CreateEmptyBoardShould_CreateABoardWithASquareNotMine_WhenInputIs1()
        {
            var board = Board.CreateEmptyBoard(1);

            var square = board.Squares[0, 0];

            Assert.False(square.IsMine);
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
            var squares = ToSquareList(board);
            var mines = squares.FindAll(x => x.IsMine);
            Assert.Single(mines);
        }
        
        private static List<Square> ToSquareList(Board board)
        {
            var squares = new List<Square>();
            var rowLength = board.Squares.GetLength(0);
            var columnLength = board.Squares.GetLength(1);
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    squares.Add(board.Squares[i, j]);
                }
            }

            return squares;
        }

  
    }
}