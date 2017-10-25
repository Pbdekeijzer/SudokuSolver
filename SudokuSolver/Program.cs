using SudokuSolver.Logic;
using SudokuSolver.Models;
using System;
using System.Collections.Generic;
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
                    new int[] {0,0,0,0,6,0,0,0,0},
                    new int[] {0,2,9,0,0,0,6,8,0},
                    new int[] {8,0,0,3,0,1,0,0,2},
                    new int[] {0,9,4,0,0,0,3,2,0},
                    new int[] {0,7,0,2,0,4,0,5,0},
                    new int[] {0,3,1,0,0,0,4,6,0},
                    new int[] {9,0,0,7,0,6,0,0,3},
                    new int[] {0,4,5,0,0,0,8,7,0},
                    new int[] {0,0,0,0,8,0,0,0,0}
                };
            
            var sudoku = BuildSudoku.Build(matrix);

            SolveSudoku.Solve(sudoku);

            sudoku.Print();
        
            Console.Read();
            
        }
    }
}
