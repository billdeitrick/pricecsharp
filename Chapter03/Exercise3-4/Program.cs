using System;
using static System.Console;

namespace Exercise3_4
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                WriteLine("Enter a number between 0 and 255:");
                int dividend = System.Convert.ToInt32(ReadLine());

                WriteLine("Enter another number between 0 and 255:");
                int divisor = System.Convert.ToInt32(ReadLine());

                WriteLine($"{dividend} divided by {divisor} is {dividend / divisor}");
            } catch (Exception ex)
            {
                WriteLine($"{ex.GetType()}: {ex.Message}");
            }
        }
    }
}
