using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotAssmt
{
    // Requirement 5: IComparer for ParkedTime
    internal class ParkedTimeComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle? x, Vehicle? y)
        {
            if (x == null || y == null) return 0;
            // Compares the ParkedTime within the Ticket object
            return x.Ticket.ParkedTime.CompareTo(y.Ticket.ParkedTime);
        }
    }
}