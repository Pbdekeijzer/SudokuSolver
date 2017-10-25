using SudokuSolver.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Models
{
    public class Sudoku : IPrintable
    {
        public List<Square> Squares { get; set; }
        public List<Row> Rows { get; set; }
        public List<Field> Fields { get; set; }
        public List<Column> Columns { get; set; }

        public void Print()
        {
            for (int i = 1; i < 82; i++)
            {
                Console.Write($"{Fields[i - 1].Number}, ");

                if (i % 9 == 0)
                {
                    Console.WriteLine("\n");
                }
            }
        }
    }
}
