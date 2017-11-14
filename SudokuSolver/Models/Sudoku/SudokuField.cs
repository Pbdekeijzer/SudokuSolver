using SudokuSolver.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Models
{
    public class SudokuField : IField<int>, IUpdatable<int>
    {
        public SudokuField(int value, SudokuBlock row, SudokuBlock column, SudokuBlock square, bool solved)
        {
            Value = value;
            Row = row;
            Column = column;
            Square = square;
            Solved = solved;
        }

        public int Value { get; set; }

        public SudokuBlock Row { get; set; }

        public SudokuBlock Column { get; set; }

        public SudokuBlock Square { get; set; }

        public List<int> PossibleNumbers { get; set; }

        public bool Solved { get; set; }

        public void Update(int value)
        {
            Value = value;
            PossibleNumbers = new List<int> { value };
            RemovePossibleNumbersFromFieldBlocks(value);
            Solved = true;
        }

        // Removes a number from all fields, except the current field, in it
        private void RemovePossibleNumbersFromFieldBlocks(int number)
        {
            RemovePossibleNumbers(Row, number);
            RemovePossibleNumbers(Square, number);
            RemovePossibleNumbers(Column, number);
        }

        private void RemovePossibleNumbers(SudokuBlock block, int number)
        {
            foreach (var _field in block.Fields)
            {
                if (_field != this)
                {
                    ((SudokuField)_field).PossibleNumbers.Remove(number);
                }
            }
        }
    }
}
