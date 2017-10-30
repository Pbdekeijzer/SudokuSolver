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
            var fields = new List<SudokuField>();
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

                fields.Add(field);

                rowsArray[rowIndex].Fields.Add(field);
                columnsArray[columnIndex].Fields.Add(field);
                squaresArray[squareIndex].Fields.Add(field);
            }

            List<SudokuBlock> rows = rowsArray.ToList();
            List<SudokuBlock> columns = columnsArray.ToList();
            List<SudokuBlock> squares = squaresArray.ToList();

            return new Sudoku
            {
                Rows = rows,
                Columns = columns,
                Squares = squares,
                Fields = fields,
            };
        }

        public static Sudoku Build(int[][] matrix)
        {
            var fields = new List<SudokuField>();
            var columnsArray = new SudokuBlock[9];
            var rowsArray = new SudokuBlock[9];
            var squaresArray = new SudokuBlock[9];

            Initialize<Column>(columnsArray);
            Initialize<Row>(rowsArray);
            Initialize<Square>(squaresArray);

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

                    fields.Add(field);

                    rowsArray[i].Fields.Add(field);
                    columnsArray[j].Fields.Add(field);
                    squaresArray[squareIndex].Fields.Add(field);
                }
            }

            List<SudokuBlock> rows = rowsArray.ToList();
            List<SudokuBlock> columns = columnsArray.ToList();
            List<SudokuBlock> squares = squaresArray.ToList();

            return new Sudoku
            {
                Rows = rows,
                Columns = columns,
                Squares = squares,
                Fields = fields,
            };
        }

        private static int GetSquareIndex(int r, int c)
        {
            int squareIndex;

            if (r < 3)
            {
                //if (c < 3), then..., else if..., then..., else...
                squareIndex = (c < 3) ? 0 : (c >= 3 && c < 6) ? 1 : 2;
            }

            else if (r >= 3 && r < 6)
            {
                squareIndex = (c < 3) ? 3 : (c >= 3 && c < 6) ? 4 : 5;
            }
            else
            {
                squareIndex = (c < 3) ? 6 : (c >= 3 && c < 6) ? 7 : 8;
            }

            return squareIndex;
        }

        private static void Initialize<T>(object[] arrayOfObjects) where T : new()
        {
            for (int i = 0; i < arrayOfObjects.Count(); i++)
            {
                arrayOfObjects[i] = new T();
            }
        }
    }
}
