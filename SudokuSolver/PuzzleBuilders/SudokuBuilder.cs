using SudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.PuzzleBuilders
{
    public static class SudokuBuilder
    {
        public static Sudoku Build(IEnumerable<int> sudoku)
        {
            var fields = new SudokuField[81];
            var columnsArray = new SudokuBlock[9];
            var rowsArray = new SudokuBlock[9];
            var squaresArray = new SudokuBlock[9];

            Initialize<Column>(columnsArray);
            Initialize<Row>(rowsArray);
            Initialize<Square>(squaresArray);

            for (int i = 0; i < 81; i++)
            {
                int columnIndex = i % 9;
                int rowIndex = Convert.ToInt32(Math.Floor((double)i / 9));
                int squareIndex = GetSquareIndex(rowIndex, columnIndex);
                int number = sudoku.ElementAt(i);

                var field = new SudokuField(number, rowsArray[rowIndex], columnsArray[columnIndex], squaresArray[squareIndex], false)
                {
                    PossibleNumbers = (number != 0) ? new List<int> { number } : new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                };

                fields[i] = field;

                rowsArray[rowIndex].Fields.Add(field);
                columnsArray[columnIndex].Fields.Add(field);
                squaresArray[squareIndex].Fields.Add(field);
            }

            return new Sudoku
            {
                Rows = rowsArray,
                Columns = columnsArray,
                Squares = squaresArray,
                Fields = fields,
            };
        }

        public static Sudoku Build(int[][] matrix)
        {
            var fields = new SudokuField[81];
            var columnsArray = new SudokuBlock[9];
            var rowsArray = new SudokuBlock[9];
            var squaresArray = new SudokuBlock[9];

            Initialize<Column>(columnsArray);
            Initialize<Row>(rowsArray);
            Initialize<Square>(squaresArray);

            int fieldcount = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int squareIndex = GetSquareIndex(i, j);
                    int number = matrix[i][j];

                    var field = new SudokuField(number, rowsArray[i], columnsArray[j], squaresArray[squareIndex], false)
                    {
                        PossibleNumbers = (number != 0) ? new List<int> { number } : new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                    };

                    fields[fieldcount] = field;

                    rowsArray[i].Fields.Add(field);
                    columnsArray[j].Fields.Add(field);
                    squaresArray[squareIndex].Fields.Add(field);

                    fieldcount++;
                }
            }

            return new Sudoku
            {
                Rows = rowsArray,
                Columns = columnsArray,
                Squares = squaresArray,
                Fields = fields,
            };
        }

        // Squares (block of 3x3 fields) in a sudoku are indexed from left to right, top to bottom, like so:
        // 1, 2, 3
        // 4, 5, 6
        // 7, 8, 9
        // By this logic, this method decides which square a field is in.
        private static int GetSquareIndex(int row, int col)
        {
            int squareIndex;

            if (row < 3)
            {                
                squareIndex = (col < 3) ? 0 : (col >= 3 && col < 6) ? 1 : 2;
            }

            else if (row >= 3 && row < 6)
            {
                squareIndex = (col < 3) ? 3 : (col >= 3 && col < 6) ? 4 : 5;
            }
            else
            {
                squareIndex = (col < 3) ? 6 : (col >= 3 && col < 6) ? 7 : 8;
            }

            return squareIndex;
        }

        // Initializes an empty object for each index in an array. 
        // This way we can assign properties of objects by index.
        private static void Initialize<T>(object[] arrayOfObjects) where T : new()
        {
            for (int i = 0; i < arrayOfObjects.Count(); i++)
            {
                arrayOfObjects[i] = new T();
            }
        }
    }
}
