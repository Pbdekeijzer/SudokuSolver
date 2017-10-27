using SudokuSolver.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SudokuSolver.Logic
{
    public static class SolveSudoku
    {
        public static void Solve(Sudoku sudoku)
        {          
            // While not all fields are solved...
            while (sudoku.Fields.Count(x => x.Solved) != 81)
            {
                foreach (Field field in sudoku.Fields.Where(x => !x.Solved).OrderBy(x => x.PossibleNumbers.Count))
                {
                    // Has only one possible number left.
                    if (field.PossibleNumbers.Count == 1)
                    {
                        UpdateField(field, field.PossibleNumbers.First(), new List<int> { field.PossibleNumbers.First() });                     
                        continue;
                    }
                    CheckIfUniquePossibleNumbers(field);
                    continue;
                }              
            }
            System.Console.WriteLine("Sudoku solved");
        }

        private static void UpdateField(Field field, int number, List<int> possibleNumbers)
        {
            field.Number = number;
            RemovePossibleNumbersFromFieldBlocks(field, number);
            field.PossibleNumbers = possibleNumbers;
            field.Solved = true;
        }

        // Checks if any of the possible numbers from a field is unique in it's row, square or column.
        private static void CheckIfUniquePossibleNumbers(Field field)
        {          
            if (UniquePossibleNumbersInBlock(field.Square, field))
                return;
            else if (UniquePossibleNumbersInBlock(field.Column, field))
                return;
            UniquePossibleNumbersInBlock(field.Row, field);

        }

        private static bool UniquePossibleNumbersInBlock(Block block, Field field)
        {
            foreach (int number in field.PossibleNumbers)
            {
                if (block.Fields.Count(x => x.PossibleNumbers.Contains(number)) == 1)
                {
                    UpdateField(field, number, new List<int> { number });
                    return true;
                }
            }
            return false;
        }

        private static void RemovePossibleNumbersFromFieldBlocks(Field field, int number)
        {
            RemovePossibleNumbers(field.Row, field, number);
            RemovePossibleNumbers(field.Square, field, number);
            RemovePossibleNumbers(field.Column, field, number);
        }

        private static void RemovePossibleNumbers(Block block, Field field, int number)
        {          
            foreach(var _field in block.Fields)
            {
                if (_field != field)
                {
                    _field.PossibleNumbers.Remove(number);
                }
            }
        }
    }
}
