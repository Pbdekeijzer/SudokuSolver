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

        public void AddField(IField<T> field)
        {
            if (Fields == null)
            {
                Fields = new List<IField<T>>();
            }
            Fields.Add(field);
        }

        public void RemoveField(IField<T> field)
        {
            if (Fields != null)
            {
                Fields.Remove(field);
            }
        }
    }
}
