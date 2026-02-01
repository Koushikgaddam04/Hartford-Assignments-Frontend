using System;
using SalaryCalculator;

namespace Week_5_CS_ASSMT_1
{
    class Exercise3
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter Employee Basic Salary: ");
                double basic = double.Parse(Console.ReadLine());

                double netSalary = Calculator.CalculateNetSalary(basic);

                Console.WriteLine("\nSalary Statement:");
                Console.WriteLine("Basic Salary : " + basic);
                Console.WriteLine("Net Salary   : " + netSalary);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}