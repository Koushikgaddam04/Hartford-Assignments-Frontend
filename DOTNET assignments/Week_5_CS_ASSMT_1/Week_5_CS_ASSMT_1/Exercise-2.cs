using System;

namespace Week_5_CS_ASSMT_1
{
    class Exercise2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Circle A Properties ---");
            Console.Write("Enter center x-coordinate (xa): ");
            double xa = double.Parse(Console.ReadLine());

            Console.Write("Enter center y-coordinate (ya): ");
            double ya = double.Parse(Console.ReadLine());

            Console.Write("Enter radius (ra): ");
            double ra = double.Parse(Console.ReadLine());

            Console.WriteLine("\n--- Circle B Properties ---");
            Console.Write("Enter center x-coordinate (xb): ");
            double xb = double.Parse(Console.ReadLine());

            Console.Write("Enter center y-coordinate (yb): ");
            double yb = double.Parse(Console.ReadLine());

            Console.Write("Enter radius (rb): ");
            double rb = double.Parse(Console.ReadLine());

            double distance = Math.Sqrt(Math.Pow(xb - xa, 2) + Math.Pow(yb - ya, 2));

            Console.WriteLine("\nResult:");
            if (distance + rb <= ra)
            {
                Console.WriteLine("B is in A");
            }
            else
            {
                Console.WriteLine("B is not in A");
            }
        }
    }
}