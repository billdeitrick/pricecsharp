using PrimeFactorsLib;
using System;

namespace PrimeFactorsApp
{
    class Program
    {

        static void Main(string[] args)
        {

            while (true)
            {
                var primeFactors = new PrimeFactors();

                Console.WriteLine("Enter the number you would like to factor (or non-number to quit): ");
                string raw = Console.ReadLine();

                int n;

                try {
                    n = Convert.ToInt32(raw);
                } catch(System.FormatException)
                {
                    break;
                }

                Console.WriteLine($"The prime factors are: { String.Join(" x ", primeFactors.getFactors(n)) }");

            }
        }
    }
}
