using ParkingLotAssmt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotAssmt
{
    internal class ParkingLot
    {
        private string _name;
        private List<Vehicle> _vehicleList;

        public string Name { get => _name; set => _name = value; }
        public List<Vehicle> VehicleList { get => _vehicleList; set => _vehicleList = value; }

        public ParkingLot() { }

        public ParkingLot(string name, List<Vehicle> vehicleList)
        {
            this._name = name;
            // Requirement 2, Point (c): pass the vehicleList value as an empty list
            this._vehicleList = new List<Vehicle>();
        }

        public void AddVehicleToParkingLot(Vehicle vehicle)
        {
            _vehicleList.Add(vehicle);
        }

        public bool RemoveVehicleFromParkingLot(string registrationNo)
        {
            // Search for the vehicle by Registration Number
            Vehicle vehicle = _vehicleList.Find(v => v.RegistrationNo.Equals(registrationNo, StringComparison.OrdinalIgnoreCase));

            if (vehicle != null)
            {
                _vehicleList.Remove(vehicle);
                return true;
            }
            return false;
        }

        public void DisplayVehicles()
        {
            if (_vehicleList.Count == 0)
            {
                Console.WriteLine("No vehicles to show");
            }
            else
            {
                Console.WriteLine($"Vehicles in {_name}");
                // Exact formatting string provided in Requirement 2, Point (e)
                Console.Write("{0,-15} {1,-10} {2,-12} {3,-7} {4}\n", "Registration No", "Name", "Type", "Weight", "Ticket No");

                foreach (var v in _vehicleList)
                {
                    // Weight is formatted to one decimal place as required
                    Console.Write("{0,-15} {1,-10} {2,-12} {3,-7:F1} {4}\n", v.RegistrationNo, v.Name, v.Type, v.Weight, v.Ticket.TicketNo);
                }
            }
        }
    }
}