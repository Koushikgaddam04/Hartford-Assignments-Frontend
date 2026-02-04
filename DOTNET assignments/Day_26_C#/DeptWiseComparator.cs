using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_26_C_
{
    internal class DeptWiseComparator : IComparer<Emp>
    {
        public int Compare(Emp? x, Emp? y)
        {
            return string.Compare(x.Department, y.Department);
        }
    }
}
