﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Models
{
    public abstract class Field<T>
    {
        public T Value { get; set; }
    }
}
