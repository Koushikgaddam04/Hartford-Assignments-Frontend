using System;
using System.Collections.Generic;
using InsuranceLibrary.Models;
using InsuranceLibrary.Services;

namespace InsuranceConsoleApp
{
    internal class Program
    {
        private static PolicyService _policyService = new PolicyService();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("===== Insurance Management System =====");
                Console.WriteLine("1. Add Policy");
                Console.WriteLine("2. View All Policies");
                Console.WriteLine("3. Search Policy by ID");
                Console.WriteLine("4. Update Policy");
                Console.WriteLine("5. Delete (Deactivate) Policy");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");

                string input = Console.ReadLine();

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    Console.WriteLine();
                    continue;
                }

                if (choice == 0)
                {
                    Console.WriteLine("Exiting...");
                    break;
                }

                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        AddPolicy();
                        break;
                    case 2:
                        ViewPolicies();
                        break;
                    case 3:
                        SearchPolicy();
                        break;
                    case 4:
                        UpdatePolicy();
                        break;
                    case 5:
                        DeletePolicy();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        // 1. Add Policy
        private static void AddPolicy()
        {
            Console.WriteLine("=== Add Policy ===");

            int id = ReadInt("Enter Policy Id: ");
            Console.Write("Enter Policy Holder Name: ");
            string holderName = Console.ReadLine();

            Console.Write("Enter Policy Type (Health/Life/Vehicle): ");
            string policyType = Console.ReadLine();

            decimal premium = ReadDecimal("Enter Premium Amount: ");
            int term = ReadInt("Enter Policy Term (years): ");

            bool isActive = true;

            InsurancePolicy policy = new InsurancePolicy(
                id,
                holderName,
                policyType,
                premium,
                term,
                isActive
            );

            bool added = _policyService.AddPolicy(policy);
            if (!added)
            {
                Console.WriteLine("Unable to add policy. Duplicate Id or max policy limit reached.");
            }
            else
            {
                Console.WriteLine("Policy added successfully.");
            }
        }

        // 2. View All Policies
        private static void ViewPolicies()
        {
            Console.WriteLine("=== View All Policies ===");

            List<InsurancePolicy> policies = _policyService.GetAllPolicies();

            if (policies.Count == 0)
            {
                Console.WriteLine("No policies found.");
                return;
            }

            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("Id  | Holder Name       | Type     | Premium    | Term | Active");
            Console.WriteLine("----------------------------------------------------------------------------");

            foreach (InsurancePolicy p in policies)
            {
                Console.WriteLine(
                    $"{p.PolicyId,-3} | " +
                    $"{p.PolicyHolderName,-16} | " +
                    $"{p.PolicyType,-8} | " +
                    $"{p.PremiumAmount,9} | " +
                    $"{p.PolicyTerm,4} | " +
                    $"{p.IsActive}"
                );
            }

            Console.WriteLine("----------------------------------------------------------------------------");
        }

        // 3. Search Policy
        private static void SearchPolicy()
        {
            Console.WriteLine("=== Search Policy By Id ===");

            int id = ReadInt("Enter Policy Id: ");

            InsurancePolicy policy = _policyService.GetPolicyById(id);

            if (policy == null)
            {
                Console.WriteLine("Policy not found.");
            }
            else
            {
                Console.WriteLine("Policy found:");
                Console.WriteLine(policy.ToString());
            }
        }

        // 4. Update Policy
        private static void UpdatePolicy()
        {
            Console.WriteLine("=== Update Policy ===");

            int id = ReadInt("Enter Policy Id to update: ");
            decimal newPremium = ReadDecimal("Enter new Premium Amount: ");
            int newTerm = ReadInt("Enter new Policy Term (years): ");

            bool updated = _policyService.UpdatePolicy(id, newPremium, newTerm);

            if (!updated)
            {
                Console.WriteLine("Policy not found. Update failed.");
            }
            else
            {
                Console.WriteLine("Policy updated successfully.");
            }
        }

        // 5. Delete (Deactivate) Policy
        private static void DeletePolicy()
        {
            Console.WriteLine("=== Delete (Deactivate) Policy ===");

            int id = ReadInt("Enter Policy Id to delete/deactivate: ");

            bool deleted = _policyService.DeletePolicy(id);

            if (!deleted)
            {
                Console.WriteLine("Policy not found. Delete failed.");
            }
            else
            {
                Console.WriteLine("Policy deactivated successfully.");
            }
        }

        // Helpers: input with TryParse

        private static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int value))
                {
                    return value;
                }

                Console.WriteLine("Invalid number, please try again.");
            }
        }

        private static decimal ReadDecimal(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (decimal.TryParse(input, out decimal value))
                {
                    return value;
                }

                Console.WriteLine("Invalid amount, please try again.");
            }
        }
    }
}
