﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Interfaces
{
    public interface IUpdatable<T>
    {
        void Update(T value);
    };

}
