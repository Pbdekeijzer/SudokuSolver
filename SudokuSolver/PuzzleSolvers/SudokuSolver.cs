using SudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.PuzzleSolvers
{
    public static class SudokuSolver
    {
        public static void Solve(Sudoku sudoku)
        {
            // While not all fields are solved...
            while (sudoku.Fields.Count(x => x.Solved) != 81)
            {
                foreach (SudokuField field in sudoku.Fields.Where(x => !x.Solved).OrderBy(x => x.PossibleNumbers.Count))
                {
                    // Has only one possible number left.
                    if (field.PossibleNumbers.Count == 1)
                    {
                        field.Update(field.PossibleNumbers.First());
                        continue;
                    }
                    CheckIfUniquePossibleNumbers(field);
                }
            }
            Console.WriteLine("Sudoku solved");
        }

        // Checks if any of the possible numbers from a field is unique in it's row, square or column.
        private static void CheckIfUniquePossibleNumbers(SudokuField field)
        {
            if (UniquePossibleNumbersInBlock(field.Square, field))
                return;
            else if (UniquePossibleNumbersInBlock(field.Column, field))
                return;
            UniquePossibleNumbersInBlock(field.Row, field);

        }

        private static bool UniquePossibleNumbersInBlock(SudokuBlock block, SudokuField field)
        {
            foreach (int number in field.PossibleNumbers)
            {
                if (block.Fields.Count(x => ((SudokuField)x).PossibleNumbers.Contains(number)) == 1)
                {
                    field.Update(number);
                    return true;
                }
            }
            return false;
        }
    }
}
