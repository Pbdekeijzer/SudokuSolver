using SudokuSolver.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Models
{
    public class Square : Block, IPrintable
    {
        public Square()
        {
            Fields = new List<Field>();
        }

        public void Print()
        {
            for (int i = 0; i < Fields.Count; i++)
            {
                if (i == 2 || i == 5)
                    Console.WriteLine($"{Fields[i].Number}, ");          
                else
                    Console.Write($"{Fields[i].Number}, ");
            }
        }
    }
}
