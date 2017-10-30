using SudokuSolver.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Models
{
    public class Row : SudokuBlock, IPrintable
    {
        public Row()
        {
            Fields = new List<Field<int>>();
        }

        public void Print()
        {
            foreach(Field<int> field in Fields)
            {
                Console.Write($"{field.Value}, ");
            }
        }
    }
}
