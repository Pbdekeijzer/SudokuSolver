using SudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Logic
{
    public static class BuildSudoku
    {
        public static Sudoku Build(IEnumerable<int> sudoku)
        {
            var fields = new List<Field>();
            var columnsArray = new Column[9];
            var rowsArray = new Row[9];
            var squaresArray = new Square[9];

            Initialize(columnsArray);
            Initialize(rowsArray);
            Initialize(squaresArray);

            for (int i = 0; i < 81; i++)
            {
                int columnIndex = i % 9;
                int rowIndex = Convert.ToInt32(Math.Floor((double)i / 9));
                int squareIndex = GetSquareIndex(rowIndex, columnIndex);

                var field = new Field(sudoku.ElementAt(i), rowsArray[rowIndex], columnsArray[columnIndex]);
                fields.Add(field);

                rowsArray[rowIndex].Fields.Add(field);
                columnsArray[columnIndex].Fields.Add(field);
                squaresArray[squareIndex].Fields.Add(field);

                field.Square = squaresArray[squareIndex];
            }

            List<Row> rows = rowsArray.ToList();
            List<Column> columns = columnsArray.ToList();
            List<Square> squares = squaresArray.ToList();

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
            var fields = new List<Field>();
            var columnsArray = new Column[9];
            var rowsArray = new Row[9];
            var squaresArray = new Square[9];

            Initialize(columnsArray);
            Initialize(rowsArray);
            Initialize(squaresArray);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int squareIndex = GetSquareIndex(i, j);

                    var field = new Field(matrix[i][j], rowsArray[i], columnsArray[j]);
                    fields.Add(field);

                    rowsArray[i].Fields.Add(field);
                    columnsArray[j].Fields.Add(field);
                    squaresArray[squareIndex].Fields.Add(field);

                    field.Square = squaresArray[squareIndex];
                }
            }

            List<Row> rows = rowsArray.ToList();
            List<Column> columns = columnsArray.ToList();
            List<Square> squares = squaresArray.ToList();
     
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

        private static void Initialize<T>(T[] arrayOfObjects) where T : new()
        {
            for (int i = 0; i < arrayOfObjects.Count(); i++)
            {
                arrayOfObjects[i] = new T();
            }
        }
    }
}
