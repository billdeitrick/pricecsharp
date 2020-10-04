using System;

namespace Formatting
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int numberOfApples = 12;
            decimal pricePerApple = 0.35M;
            Console.WriteLine("{0} apples costs {1:C}", arg0:numberOfApples, arg1:pricePerApple * numberOfApples);

            string formatted = String.Format(format: "{0} apples costs {1:C}", arg0:numberOfApples, arg1: pricePerApple * numberOfApples);

            Console.WriteLine($"{numberOfApples} apples costs {pricePerApple * numberOfApples:C}");

            string applesText = "Apples";
            int applesCount = 1234;
            string bananasText = "Bananas";
            int bananasCount = 56789;
            Console.WriteLine(
                format: "{0,-8} {1, 6:N0}",
                arg0: "Name",
                arg1: "Count"
            );

        }
    }
}
