using System;

namespace Week_5_CS_ASSMT_1
{
    class Exercise4
    {
        static void Main(string[] args)
        {

            Console.Write("Enter Customer ID: ");
            string customerId = Console.ReadLine();

            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();

            Console.Write("Enter Address: ");
            string address = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write("Enter Email ID: ");
            string email = Console.ReadLine();

            Console.Write("Enter Type of Connection (Industrial, Business, Domestic, Agricultural): ");
            string type = Console.ReadLine();

            Console.Write("Enter Previous Reading: ");
            double prevReading = double.Parse(Console.ReadLine());

            Console.Write("Enter Current Reading: ");
            double currReading = double.Parse(Console.ReadLine());

            double units = currReading - prevReading;
            double charges = 0;

            if (units <= 100) charges = units * 1.5;
            else if (units <= 250) charges = (100 * 1.5) + ((units - 100) * 2.5);
            else if (units <= 550) charges = (100 * 1.5) + (150 * 2.5) + ((units - 250) * 4.5);
            else if (units > 1000) charges = (100 * 1.5) + (150 * 2.5) + (300 * 4.5) + ((units - 550) * 7.5);
            else charges = (100 * 1.5) + (150 * 2.5) + ((units - 250) * 4.5);

            double rent = 0;
            if (type == "Industrial") rent = 2500;
            else if (type == "Business") rent = 1500;
            else if (type == "Domestic") rent = 1000;

            double total = charges + rent;
            Console.WriteLine("\n");
            Console.WriteLine("ELECTRICITY BILL            ");
            Console.WriteLine("ID             : " + customerId);
            Console.WriteLine("Name           : " + customerName);
            Console.WriteLine("Address        : " + address);
            Console.WriteLine("Contact        : " + phone);
            Console.WriteLine("Type           : " + type);
            Console.WriteLine("Units Consumed : " + units);
            Console.WriteLine("Energy Charges : " + charges.ToString());
            Console.WriteLine("Fixed Rent     : " + rent.ToString());
            Console.WriteLine("NET PAYABLE    : " + total.ToString());
        }
    }
}