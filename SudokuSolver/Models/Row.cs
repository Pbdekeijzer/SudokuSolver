using SudokuSolver.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Models
{
    public class Row : Block, IPrintable
    {
        public Row()
        {
            Fields = new List<Field>();
        }

        public void Print()
        {
            foreach(Field field in Fields)
            {
                Console.Write($"{field.Number}, ");
            }
        }
    }
}
