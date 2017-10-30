using SudokuSolver.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Models
{
    public class SudokuField : Field<int>
    {
        public SudokuField(int value, SudokuBlock row, SudokuBlock column, SudokuBlock square, bool solved)
        {
            Value = value;
            Row = row;
            Column = column;
            Square = square;
            Solved = solved;
        }

        public SudokuBlock Row { get; set; }
        public SudokuBlock Column { get; set; }
        public SudokuBlock Square { get; set; }
        public List<int> PossibleNumbers { get; set; }
        public bool Solved { get; set; }
    }
}
