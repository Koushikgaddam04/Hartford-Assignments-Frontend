using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_26_C_
{
    internal class Program
    {
        public static void Main(string[] args) {
            Emp e1 = new Emp(1, "Kishor", "CEO", 1000000);
            Emp e2 = new Emp(2, "Amit", "Manager", 5000000);
            Emp e3 = new Emp(3, "John", "Developer", 200000);
            List<Emp> employees = new List<Emp>() { e1, e2, e3 };
            Console.WriteLine("Enter an option to sort the employee list");
            Console.WriteLine("1. Sort by Salary");
            Console.WriteLine("2. Sort by Department");
            Console.WriteLine("3. Sort by Name");

            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(n);
            switch (n)
            {
                case 1:
                    employees.Sort();
                    break;
                case 2:
                    employees.Sort(new DeptWiseComparator());
                    break;
                case 3:
                    employees.Sort(new NameWiseComparator());
                    break;
                default:
                    employees.Sort();
                    employees.Sort(new DeptWiseComparator());
                    employees.Sort(new NameWiseComparator());
                    break;
            }
            foreach (Emp emp in employees)
            {
                Console.WriteLine(emp.ToString());
                //Console.WriteLine($"Id: {emp.Id}, Name: {emp.Name}, Position: {emp.Department}, Salary: {emp.Salary}");
            }
        }
    }
}
