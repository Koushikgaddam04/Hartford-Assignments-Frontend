using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

namespace OopsBasic
{
    internal class Program
    {
        class Vehicle
        {
            public virtual void disp() { Console.WriteLine("Hello Vehicle"); }
        }
        class Car : Vehicle
        {
            public override void disp() { Console.WriteLine("Hello Car"); }
        }
        static void Main(string[] args)
        {
            Car a = new Car();
            Vehicle b = new Car();
            Vehicle c = new Vehicle();
            a.disp();
            b.disp();
            c.disp();
        }
    }
}
