using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_26_C_
{
    internal class NameWiseComparator : IComparer<Emp>
    {
        public int Compare(Emp? x, Emp? y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
