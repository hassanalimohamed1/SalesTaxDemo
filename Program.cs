using System;
using static System.Console;
namespace SalesTaxDemo
{
    class SalesTaxDemo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SalesTax[] sales = new SalesTax[3];
            for (int x = 0; x < sales.Length; x++)
            {
                sales[x] = new SalesTax();
                WriteLine($"Enter Inventory Number: {x+1}");
                sales[x].Inventory = ReadLine();
                WriteLine("Enter the Sales Amount:");
                sales[x].Amount = Convert.ToDouble(ReadLine());
            }
            for (int x = 0; x < sales.Length; x++)
            {
                WriteLine($"Sales #{sales[x].Inventory} has Amount: {sales[x].Amount}");
                Write($"The tax is: {sales[x].Amount.ToString("C")}. ");
            }
        }
    }

    class SalesTax
    {
        public string Inventory { set; get; }
        private double amount;
        private double tax;
        public const double LIMIT = 100;
        public const double LOWRATE = 0.08;
        public const double HIGHRATE = 0.06;

        public double Amount
        {
            set
            {
                amount = value;
                CalculateTax();
            }
            get
            {
                return amount;
            }
        }
        public double Tax
        {
            get
            {
                return tax;
            }
        }

        public void CalculateTax()
        {
            if (Amount <= LIMIT)
                tax = Amount * LOWRATE;
            else
                tax = LIMIT * LOWRATE + (Amount - LIMIT) * HIGHRATE;
        }
    }
}