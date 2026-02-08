namespace ConsoleApp1
{
    class A
    {
        static A() { Console.WriteLine("S"); }
        public A() { Console.WriteLine("I"); }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            new A();
            new A();
        }
    }
}
