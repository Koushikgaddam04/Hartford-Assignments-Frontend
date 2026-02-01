using System;

namespace SalaryCalculator
{
    public class Calculator
    {
        public static double CalculateNetSalary(double basicSalary)
        {
            if (basicSalary < 0)
            {
                throw new ArgumentException("Salary cannot be negative.");
            }

            double hra = basicSalary * 0.20;
            double da = basicSalary * 0.10;
            double pf = 0;

            if (basicSalary >= 15000)
            {
                pf = basicSalary * 0.12;
            }

            double netSalary = (basicSalary + hra + da) - pf;
            return netSalary;
        }
    }
}