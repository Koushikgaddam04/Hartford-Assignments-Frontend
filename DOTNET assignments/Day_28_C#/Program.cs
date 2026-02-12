using static Day_28_C_.Abc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml.Linq;


namespace Day_28_C_
{
    internal class Program
    {
        
        public delegate void Hello();
        public static void show(){print("Hello");}



        public delegate void MathOps(int a, int b);
        public static void Add(int a, int b) => print(a + b);
        public static void Sub(int a, int b) => print(a - b);
        public static void Mul(int a, int b) => print(a * b);
        public static void Div(int a, int b) => print(a / b);



        static void Main(string[] args)
        {

            int[] arr = { 10, 647, 2, 536, 648, 64, 25, 13, 87, 56 };
            var query = from n in arr
                        where n % 2 == 0
                        select n;

            print(string.Join(' ', query));
           
            print("After");
            arr[3] = 14;
            print(string.Join(' ', query));

            //Single cast delegates
            Hello h = new Hello(show);
            h();
            Hello h1 = show;
            h1();

            //Multicast delegates
            MathOps ops = Add;
            ops += Sub;
            ops += Mul;
            ops += Div;

            ops(10, 5);

            //Action
            Action<string> greet = name => print($"Hi, {name}!");
            greet("Kishor");

            //Func
            Func<int,int,int> x = (a, b) => a + b;
            print(x(10, 20));

            //Predicate
            Predicate<int> y = n => n % 2 == 0;
            print("Enter a number: ");
            //int num = int.Parse(Console.ReadLine());
            //print($"{num} is an "+(y(num)?"even":"odd") + " number");

        }
    }
}
