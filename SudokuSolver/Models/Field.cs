using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Models
{
    public class Field
    {
        public Field(int number, Row row, Column column)
        {
            Row = row;
            Column = column;
            Number = number;
            PossibleNumbers = (number != 0) ? new List<int> { number } : new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Solved = false; // Solved is false even if number != 0, because it still needs to remove values from other possiblevalue fields before it is solved.
        }

        public Square Square { get; set; }
        public Row Row { get; set; }
        public Column Column { get; set; }
        public List<int> PossibleNumbers { get; set; }
        public int Number { get; set; }
        public bool Solved { get; set; }
    }
}
