using SudokuSolver.Logic;
using SudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new int[][] 
                {
                    new int[] {3,0,0,6,0,2,0,0,5},
                    new int[] {0,6,0,0,0,0,0,7,0},
                    new int[] {0,0,5,0,1,0,9,0,0},
                    new int[] {2,0,0,1,0,9,0,0,4},
                    new int[] {0,0,6,0,0,0,2,0,0},
                    new int[] {8,0,0,2,0,6,0,0,1},
                    new int[] {0,0,4,0,3,0,7,0,0},
                    new int[] {0,5,0,0,0,0,0,2,0},
                    new int[] {1,0,0,7,0,8,0,0,6}
                };

            var sudoku = BuildSudoku.Build(matrix);

            SolveSudoku.Solve(sudoku);

            sudoku.Print();
        
            Console.Read();
            
        }
    }
}
