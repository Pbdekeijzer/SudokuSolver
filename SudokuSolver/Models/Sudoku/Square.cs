using SudokuSolver.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Models
{
    public class Square : SudokuBlock, IPrintable
    {
        public Square()
        {
            Fields = new List<Field<int>>();
        }

        public void Print()
        {
            var fieldsArray = Fields.ToArray();
            for (int i = 0; i < Fields.Count(); i++)
            {
                if (i == 2 || i == 5)
                    Console.WriteLine($"{fieldsArray[i].Value}, ");
                else
                    Console.Write($"{fieldsArray[i].Value}, ");
            }
        }
    }
}
