using System;

namespace Day_27_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank b = new Bank("Kishor", 1, 10000);
            try
            {
                while (true)
                {
                    Console.WriteLine("Option - 1: Withdraw amount");
                    Console.WriteLine("Option - 2: Read Balance");
                    Console.WriteLine("Option - 3: Exit");
                    Console.WriteLine("Enter option: ");
                    int opt = int.Parse(Console.ReadLine());
                    switch (opt)
                    {
                        case 1:
                            Console.WriteLine("Enter amount to withdraw: ");
                            int amt = int.Parse(Console.ReadLine());
                            b.Withdraw(amt);
                            break;
                        case 2:
                            b.getBal();
                            break;
                        case 3:
                            return;

                    }
                }
            }catch(BankException ex)
            {
                ex.disp();
            }
        }
    }

    internal class Bank
    {
        public string v1;
        public int v2;
        public int v3;
        public Bank(string a, int b, int c)
        {
            v1 = a;
            v2 = b;
            v3 = c;
        }

        internal void Withdraw(int v)
        {
            if(v3-v < 2000) throw new BankException(v2, v3);
            v3 -= v;
        }

        public void getBal()
        {
            Console.WriteLine(v3);
        }
    }

    internal class BankException : Exception
    {
        int acc;
        int bal;

        public BankException(int a, int b)
        {
            acc = a;
            bal = b;
        }

        public void disp()
        {
            Console.WriteLine($"Account Number: {acc}\nBalance Left: {bal}\nCant Withdraw money");
        }
    }
}
