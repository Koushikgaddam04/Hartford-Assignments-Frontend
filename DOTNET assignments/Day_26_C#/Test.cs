using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Security.Cryptography;

namespace Day_26_C_
{
    internal class Test
    {
        static void Main(string[] args)
        {
            //List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            //int[] a = new int[] { 6, 7, 8, 9, 10 };
            //ArrayList arrayList = new ArrayList();
            //arrayList.Add(100);
            //arrayList.Add("Hello");
            //Console.WriteLine(a[5]);
            Car c1 = new Car("BMW", 28, "sedan", "V8");
            Car c2 = new Car("BMW", 22, "SUV", "V12");
            Console.WriteLine(c1.Equals(c2) ? "Equal" : "Not Equal");
            c1.GetType().GetProperties();
            Console.WriteLine(c1.GetType().GetProperties());
            PropertyInfo[] properties = c1.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(property.Name + " : " + property.GetValue(c1));
            }

            List<Car> cars = new List<Car>();
            cars.Add(c1);
            cars.Add(c2);
            //foreach (Car car in c1.GetType().GetProperties())
            //{
            //    cars.Add(car);
            //}

            //Sorting based on V2
            cars.Sort((x, y) => x.V2.CompareTo(y.V2));
            foreach (Car car in cars)
            {
                Console.WriteLine(car.V1 + " " + car.V2);
            }


        }

    }



    internal class Car
    {
        public Car(string v1, int v2, string v3, string v4)
        {
            V1 = v1;
            V2 = v2;
            V3 = v3;
            V4 = v4;
        }

        public string V1 { get; }
        public int V2 { get; }
        public string V3 { get; }
        public string V4 { get; }

        //public override bool Equals(object obj)
        //{
        //    Car c = obj as Car;
        //    if (this.V == c.V)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public int CompareTo(Car? other)
        {
            if (other == null) return 1;
            return this.V2.CompareTo(other.V2);
        }
    }
}
