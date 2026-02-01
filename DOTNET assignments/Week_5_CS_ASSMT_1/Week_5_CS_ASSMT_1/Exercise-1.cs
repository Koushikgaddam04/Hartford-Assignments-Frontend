using System;

namespace Week_5_CS_ASSMT_1
{
    class Exercise1
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                long runs = (long)(i * i * i) - i;
                Console.Write(runs + (i == n ? "" : ", "));
            }
        }
    }
}