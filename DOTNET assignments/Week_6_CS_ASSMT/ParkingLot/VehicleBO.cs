using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotAssmt
{
    internal class VehicleBO
    {
        // Search by Type 
        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, string type)
        {
            List<Vehicle> result = new List<Vehicle>();
            foreach (var v in vehicleList)
            {
                // Comparing type (case-insensitive) 
                if (v.Type.Equals(type, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(v);
                }
            }
            return result;
        }

        // Search by Parked Time 
        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, DateTime parkedTime)
        {
            List<Vehicle> result = new List<Vehicle>();
            foreach (var v in vehicleList)
            {
                // Comparing DateTime objects 
                if (v.Ticket.ParkedTime == parkedTime)
                {
                    result.Add(v);
                }
            }
            return result;
        }
    }
}