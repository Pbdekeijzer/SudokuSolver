using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Models
{
    public interface IField<T>
    {
        T Value { get; set; }
        void Update(T value);
    }
}
