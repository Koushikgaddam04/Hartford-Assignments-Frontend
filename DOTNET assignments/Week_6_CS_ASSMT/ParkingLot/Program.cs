using System;
using System.Collections.Generic;

//import this below line for regex validation in Requirement 3
using System.Text.RegularExpressions;

namespace ParkingLotAssmt
{
    class Program
    {
        static void Main(string[] args)
        {

            int choice;
            do
            {
                Console.WriteLine("\n--- Parking Lot Management System ---");
                Console.WriteLine("1. Test Requirement 1 (Basic Objects & Equals)");
                Console.WriteLine("2. Test Requirement 2 (Parking Lot Menu)");
                Console.WriteLine("3. Test Requirement 3 (Regex Validation)");
                Console.WriteLine("4. Test Requirement 4 (Search Vehicles)");
                Console.WriteLine("5. Test Requirement 5 (Sorting)");
                Console.WriteLine("6. Test Requirement 6 (Dictionary Count)");
                Console.WriteLine("7. Exit");
                Console.WriteLine("Enter your choice:");

                if (!int.TryParse(Console.ReadLine(), out choice)) continue;

                switch (choice)
                {
                    case 1: Requirement1(); break;
                    case 2: Requirement2(); break;
                    case 3: Requirement3(); break;
                    case 4: Requirement4(); break;
                    case 5: Requirement5(); break;
                    case 6: Requirement6(); break;
                }
            } while (choice <= 6);


            static void Requirement1()
            {
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("------------------- Starting of Requirement - 1 ---------------------");
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine();

                Console.WriteLine("Enter Vehicle 1 details:");
                string input1 = Console.ReadLine();

                Console.WriteLine("Enter Vehicle 2 details:");
                string input2 = Console.ReadLine();

                Vehicle v1 = Vehicle.CreateVehicle(input1);
                Vehicle v2 = Vehicle.CreateVehicle(input2);

                Console.WriteLine("\nVehicle 1");
                Console.WriteLine(v1.ToString());

                Console.WriteLine();

                Console.WriteLine("Vehicle 2");
                Console.WriteLine(v2.ToString());

                Console.WriteLine();

                // Requirement: Case-insensitive comparison
                Console.Write("Vehicle 1 and Vehicle 2 are ");
                Console.WriteLine(v1.Equals(v2) ? "same" : "different");
            }





            static void Requirement2()
            {
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("------------------- Starting of Requirement - 2 ---------------------");
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine();

                Console.WriteLine("Enter the name of the Parking Lot:");
                string lotName = Console.ReadLine();

                // Per Requirement 2, Point (c): pass an empty list to the constructor
                ParkingLot lot = new ParkingLot(lotName, new List<Vehicle>());

                int choice;
                do
                {
                    Console.WriteLine("1.Add Vehicle\n2.Delete Vehicle\n3.Display Vehicles\n4.Exit");
                    Console.WriteLine("Enter your choice:");

                    if (!int.TryParse(Console.ReadLine(), out choice)) continue;

                    switch (choice)
                    {
                        case 1:
                            // Taking vehicle details as a single comma-separated string
                            Console.WriteLine("Enter Vehicle Details:\n");
                            string detail = Console.ReadLine();
                            lot.AddVehicleToParkingLot(Vehicle.CreateVehicle(detail));
                            Console.WriteLine("Vehicle successfully added");
                            break;
                        case 2:
                            Console.WriteLine("Enter the registration number of the vehicle to be deleted:");
                            string reg = Console.ReadLine();
                            if (lot.RemoveVehicleFromParkingLot(reg))
                            {
                                Console.WriteLine("Vehicle successfully deleted");
                            }
                            else
                            {
                                Console.WriteLine("Vehicle not found in parkinglot");
                            }
                            break;
                        case 3:
                            lot.DisplayVehicles();
                            break;
                    }
                } while (choice != 4);
            }





            static void Requirement3()
            {

                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("------------------- Starting of Requirement - 3 ---------------------");
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine();


                Console.WriteLine("Enter the registration no. to be validated:\n");
                string registrationNo = Console.ReadLine();
                Console.Write("Registration No. is ");
                Console.WriteLine(ValidateRegistrationNo(registrationNo) ? "valid" : "invalid");
            }








            static void Requirement4()
            {
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("------------------- Starting of Requirement - 4 ---------------------");
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine();

                VehicleBO vBO = new VehicleBO();
                List<Vehicle> allVehicles = new List<Vehicle>();

                Console.WriteLine("Enter the number of vehicles:");
                int num = int.Parse(Console.ReadLine());

                for (int i = 0; i < num; i++)
                {
                    Console.WriteLine($"Enter details of vehicle {i + 1}:");
                    string vDetail = Console.ReadLine();
                    allVehicles.Add(Vehicle.CreateVehicle(vDetail));
                }

                while (true)
                {
                    Console.WriteLine("Enter a search type:");
                    Console.WriteLine("1.By type\n2.By parked time\n3.Exit");
                    int searchChoice = int.Parse(Console.ReadLine());

                    List<Vehicle> searchResult = new List<Vehicle>();

                    if (searchChoice == 1)
                    {
                        Console.WriteLine("Enter the vehicle type");
                        string searchType = Console.ReadLine();
                        searchResult = vBO.FindVehicle(allVehicles, searchType);
                    }
                    else if (searchChoice == 2)
                    {
                        Console.WriteLine("Enter the parked time:");
                        string timeStr = Console.ReadLine();
                        DateTime searchTime = DateTime.ParseExact(timeStr, "dd-MM-yyyy HH:mm:ss", null);
                        searchResult = vBO.FindVehicle(allVehicles, searchTime);
                    }
                    else if (searchChoice == 3)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Choice");
                        continue;
                    }

                    // Display results
                    if (searchChoice == 1 || searchChoice == 2)
                    {
                        if (searchResult.Count == 0)
                        {
                            Console.WriteLine("No such vehicle is present");
                        }
                        else
                        {
                            // Table header as per requirement 
                            Console.Write("{0,-15} {1,-10} {2,-12} {3,-7} {4}\n", "Registration No", "Name", "Type", "Weight", "Ticket No");
                            foreach (var v in searchResult)
                            {
                                Console.Write("{0,-15} {1,-10} {2,-12} {3,-7:F1} {4}\n", v.RegistrationNo, v.Name, v.Type, v.Weight, v.Ticket.TicketNo);
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }





            static void Requirement5()
            {

                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("------------------- Starting of Requirement - 5 ---------------------");
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine();

                Console.WriteLine("Enter the number of vehicles:");
                int count = int.Parse(Console.ReadLine());
                List<Vehicle> sortList = new List<Vehicle>();

                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"Enter details of vehicle {i + 1}:");
                    string data = Console.ReadLine();
                    sortList.Add(Vehicle.CreateVehicle(data));
                }
                while (true)
                {
                    Console.WriteLine("Enter a search type:");
                    Console.WriteLine("1.Sort by Weight\n2.Sort by Parking Time\n3.Exit");
                    int sortChoice = int.Parse(Console.ReadLine());

                    if (sortChoice == 1)
                    {
                        // Uses the CompareTo method in Vehicle class
                        sortList.Sort();
                        Console.Write("{0,-15} {1,-10} {2,-12} {3,-7} {4}\n", "Registration No", "Name", "Type", "Weight", "Ticket No");
                        foreach (var v in sortList)
                        {
                            Console.Write("{0,-15} {1,-10} {2,-12} {3,-7:F1} {4}\n", v.RegistrationNo, v.Name, v.Type, v.Weight, v.Ticket.TicketNo);
                        }
                        Console.WriteLine();
                    }
                    else if (sortChoice == 2)
                    {
                        // Uses the ParkedTimeComparer class
                        sortList.Sort(new ParkedTimeComparer());
                        Console.Write("{0,-15} {1,-10} {2,-12} {3,-20} {4}\n", "Registration No", "Name", "Type", "Parked-Time", "Ticket No");
                        foreach (var v in sortList)
                        {
                            Console.Write("{0,-15} {1,-10} {2,-12} {3,-20} {4}\n", v.RegistrationNo, v.Name, v.Type, v.Ticket.ParkedTime, v.Ticket.TicketNo);
                        }
                        Console.WriteLine();
                    }
                    else if (sortChoice == 3)
                    {
                        break;
                    }else
                    {
                        Console.WriteLine("Invalid Choice");
                        continue;
                    }
                    Console.WriteLine();
                }
            }
            static void Requirement6()
            {
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("------------------- Starting of Requirement - 6 ---------------------");
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine();

                Console.WriteLine("Enter the number of vehicles:");
                int totalVehicles = int.Parse(Console.ReadLine());
                List<Vehicle> dictList = new List<Vehicle>();

                for (int i = 0; i < totalVehicles; i++)
                {
                    Console.WriteLine($"Enter details of vehicle {i + 1}:");
                    string input = Console.ReadLine();
                    dictList.Add(Vehicle.CreateVehicle(input));
                }

                // Call the static method directly from the Vehicle class
                Dictionary<string, int> resultDict = Vehicle.GetVehicleCountByType(dictList);

                // Formatting the output
                Console.WriteLine("{0,-15} {1}", "Type", "Count");
                foreach (KeyValuePair<string, int> entry in resultDict)
                {
                    Console.WriteLine("{0,-15} {1}", entry.Key, entry.Value);
                }
            }
        }

        static bool ValidateRegistrationNo(string registrationNo)
        {
            string[] test = registrationNo.Split(' ');
            if (test.Length < 3 || test.Length > 4) return false;

            //To see of the last part of the registration number is strictly greater than 0 and less than or equal to 9999
            if(!int.TryParse(test[test.Length - 1], out int X) || X <= 0 || X > 9999) return false;

            // Requirement 3: Registration number validation using Regex
            string pattern = @"^[A-Z]{2}\s\d{1,2}(\s[A-Z]{0,2})?\s\d{1,4}$";
            return Regex.IsMatch(registrationNo, pattern);
        }
    }
}