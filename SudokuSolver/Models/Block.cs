using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Models
{
    // Is a Row, Column or Square
    public abstract class Block
    {
        public List<Field> Fields { get; protected set; }
    }
}
