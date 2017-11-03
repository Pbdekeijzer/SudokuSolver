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
            Fields = new List<IField<int>>();
        }

        public void Print()
        {
            foreach(IField<int> field in Fields)
            {
                Console.Write($"{field.Value}, ");
            }
        }
    }
}
