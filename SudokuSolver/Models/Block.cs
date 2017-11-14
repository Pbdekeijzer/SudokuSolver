using SudokuSolver.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Models
{
    public abstract class Block<T>
    {
        public List<IField<T>> Fields { get; set; }
    }
}
