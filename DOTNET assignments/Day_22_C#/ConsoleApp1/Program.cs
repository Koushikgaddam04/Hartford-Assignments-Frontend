using Calculator;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            int y = 20;

            float res = MyMath.add(x, y);

            Console.WriteLine($"Result of {x} + {y} = {res}");

            int a = int.Parse(Console.ReadLine());
            Console.WriteLine($"Value A: {a}");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Value B: {b}");
            int c = (int)b;
            Console.WriteLine($"Value C: {c}");
        }
    }
}
