using System;

namespace ParkingLotAssmt
{
    internal class Vehicle : IComparable<Vehicle>
    {
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;
        private Ticket _ticket;

        public string RegistrationNo { get => _registrationNo; set => _registrationNo = value; }
        public string Name { get => _name; set => _name = value; }
        public string Type { get => _type; set => _type = value; }
        public double Weight { get => _weight; set => _weight = value; }
        public Ticket Ticket { get => _ticket; set => _ticket = value; }

        public Vehicle() { }

        public Vehicle(string registrationNo, string name, string type, double weight, Ticket ticket)
        {
            this._registrationNo = registrationNo;
            this._name = name;
            this._type = type;
            this._weight = weight;
            this._ticket = ticket;
        }

        // Static method to create vehicle from a comma-separated string
        public static Vehicle CreateVehicle(string detail)
        {
            string[] s = detail.Split(',');

            // Format: registrationNo, name, type, weight, ticketNo, parkedTime, cost
            string regNo = s[0].Trim();
            string vName = s[1].Trim();
            string vType = s[2].Trim();
            double vWeight = double.Parse(s[3].Trim());

            string tNo = s[4].Trim();
            // Using ParseExact as specified in Requirement 2
            DateTime pTime = DateTime.ParseExact(s[5].Trim(), "dd-MM-yyyy HH:mm:ss", null);
            double tCost = double.Parse(s[6].Trim());

            Ticket ticket = new Ticket(tNo, pTime, tCost);
            return new Vehicle(regNo, vName, vType, vWeight, ticket);
        }

        public override string ToString()
        {
            return $"Registration No:{_registrationNo}\nName:{_name}\nType:{_type}\nWeight:{_weight:F1}\nTicket No:{_ticket.TicketNo}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Vehicle)) return false;
            Vehicle other = (Vehicle)obj;
            return string.Equals(this._registrationNo, other._registrationNo, StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(this._name, other._name, StringComparison.OrdinalIgnoreCase);
        }


        //Requirement - 5: Implement IComparable<Vehicle> to sort vehicles by weight
        public int CompareTo(Vehicle? other)
        {
            if(other == null) return 1;
            return this.Weight.CompareTo(other.Weight);
        }

        // Requirement 6: Static method to count vehicles by type using a Dictionary
        public static Dictionary<string, int> GetVehicleCountByType(List<Vehicle> vehicleList)
        {
            Dictionary<string, int> countMap = new Dictionary<string, int>();
            foreach (var v in vehicleList)
            {
                // We use the Type property as the key
                string type = v.Type;
                countMap[type] = countMap.ContainsKey(type) ? ++countMap[type] : 1;
            }
            return countMap;
        }
    }
}