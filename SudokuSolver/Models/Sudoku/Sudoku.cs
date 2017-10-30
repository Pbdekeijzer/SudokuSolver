using SudokuSolver.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Models
{
    public class Sudoku : IPrintable, ISolvable
    {
        public List<SudokuBlock> Squares { get; set; }
        public List<SudokuBlock> Rows { get; set; }
        public List<SudokuBlock> Columns { get; set; }
        public List<SudokuField> Fields { get; set; }

        public void Print()
        {
            for (int i = 1; i < 82; i++)
            {
                Console.Write($"{Fields[i - 1].Value}, ");

                if (i % 9 == 0)
                {
                    Console.WriteLine("\n");
                }
            }
        }

        public void Solve()
        {
            PuzzleSolvers.SudokuSolver.Solve(this);
        }
    }
}
