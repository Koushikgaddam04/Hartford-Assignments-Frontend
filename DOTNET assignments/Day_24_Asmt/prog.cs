using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsBasic
{
        //public class Car
        //{
        //    public string color = "red";
        //static void display() { Console.WriteLine("Hello World"); }
    //}
    public class prog
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 34, 12, 5, 67, 23, 89, 2, 45 };
            int[] brr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            int m = arr.Max();
            System.Console.WriteLine(m);
            Console.WriteLine(arr);
            foreach (var item in arr)
            {
                Console.Write(item);
                Console.Write(" ");
            }
            Console.WriteLine("");

            int n = 257;
            byte n1 = (byte)n;
            Console.WriteLine(n1);

            //int d = 10 / 4;
            Console.WriteLine(10 / 4);


            try
            {
                double a = double.MaxValue;
                Console.WriteLine(a);
                int temp = unchecked((int)a);
                Console.WriteLine(temp);
            }
            catch (System.OverflowException e)
            {
                Console.WriteLine($"Error Occurred: {e.Message}");
            }

            Console.WriteLine("\n");
            try
            {
                double a = double.MaxValue;
                a += 1;
                Console.WriteLine(a);
            }
            catch (System.OverflowException e)
            {
                Console.WriteLine($"Error Occurred: {e.Message}");
            }

            //Console.WriteLine(double.MinValue);

            //string concatenation
            //StringBuilder sb = new StringBuilder();

            Console.WriteLine("\nTry Parse");
            bool flag = double.TryParse("123.7648", out double res);
            Console.WriteLine(flag);
            Console.WriteLine(res);

            string s = "SuperHeroWorld!";
            Console.WriteLine(s.ToLower());
            Console.WriteLine(s.Max());
            Console.WriteLine(arr.Average());
            Console.WriteLine(s.Contains("World"));
            Console.WriteLine(s.StartsWith("Hel"));
            Console.WriteLine(s.EndsWith("ld!"));
            Console.WriteLine(s.Substring(2));

            Console.WriteLine("\nIncrement");
            static void inc(int x)
            {
                x++;
            }
            int p = 10;
            inc(p);
            Console.WriteLine(p);



            string s1 = "1 2 3 4 5";
            Console.WriteLine(s1.Split(" "));

            Console.WriteLine(s1);

            static int Sum(params int[] ar)
            {
                int tot = 0;
                foreach (var item in ar)
                {
                    tot += item;
                }
                return tot;
            }
            int n2 = Sum(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            Console.WriteLine(n2);
            Console.WriteLine(Sum(arr));

            string hello = "Hello";
            hello.Replace("H", "J");
            Console.WriteLine(hello);




            static void display(List<int> numbers)
            {
                foreach (var item in numbers)
                {
                    Console.Write(item);
                    Console.Write(" ");
                }
                Console.WriteLine("\n");
            }
            var nums = new List<int> { 10, 20, 30, 40, 50 };
            var numsB = new List<int> { 48, 45, 80, 92, 55 };
            Console.WriteLine($"Count - {nums.Count()}");
            display(nums);
            var t = nums;
            t[1] = 55;
            display(t);
            display(nums);

            nums.Add(100);
            display(nums);

            nums.AddRange(new List<int> { 50, 60 });
            display(nums);

            nums.AddRange(numsB);
            display(nums);

            nums.Insert(4, 44);
            display(nums);

            nums.InsertRange(8, new List<int> { 10, 10, 10, 10, 10 });
            display(nums);

            nums.Remove(10);
            display(nums);

            nums.RemoveAll(x => x == 10);
            display(nums);

            nums.RemoveAt(4);
            display(nums);

            nums.Sort();
            display(nums);

            nums.RemoveRange(4, 2);
            display(nums);

            Console.WriteLine(nums.Contains(41));
            Console.WriteLine(nums.IndexOf(55));
            Console.WriteLine(nums.LastIndexOf(55));
            Console.WriteLine(nums.Find(x => x >= 80));
            Console.WriteLine(nums.FindAll(x => x >= 80));

            bool allPos = nums.TrueForAll(x => x > 0);
            Console.WriteLine(allPos);

            //nums.Sort((x,y) => y.CompareTo(x));
            nums.Sort((x, y) => y - x);
            display(nums);

            nums.Reverse();
            display(nums);

            //Convert list to array
            int[] arr2 = nums.ToArray();
            Console.WriteLine("Converted to array");

            //convert array to list
            List<int> list2 = arr2.ToList();
            Console.WriteLine("Converted to List");
            display(list2);
        }
    }
}
