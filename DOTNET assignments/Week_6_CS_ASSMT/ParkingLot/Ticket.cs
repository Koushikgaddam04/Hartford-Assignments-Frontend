using System;

namespace ParkingLotAssmt
{
    internal class Ticket
    {
        private string _ticketNo;
        private DateTime _parkedTime;
        private double _cost;

        public string TicketNo { get => _ticketNo; set => _ticketNo = value; }
        public DateTime ParkedTime { get => _parkedTime; set => _parkedTime = value; }
        public double Cost { get => _cost; set => _cost = value; }

        // Default constructor as per Requirement 2
        public Ticket() { }

        // Parameterized constructor
        public Ticket(string ticketNo, DateTime parkedTime, double cost)
        {
            this._ticketNo = ticketNo;
            this._parkedTime = parkedTime;
            this._cost = cost;
        }
    }
}