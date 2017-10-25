using SudokuSolver.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Models
{
    public class Column : Block, IPrintable
    {
        public Column()
        {
            Fields = new List<Field>();
        }

        public void Print()
        {
            foreach(Field field in Fields)
            {
                Console.WriteLine($"{field.Number}, ");
            }
        }
    }
}
