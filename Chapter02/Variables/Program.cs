using System;

namespace Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            object height = 1.88;
            object name ="Amir";

            Console.WriteLine($"{name} is {height} meters tall.");

            //int length1 = name.Length;
            int length2 = ((string)name).Length;
            Console.WriteLine($"{name} has {length2} characters.");

            dynamic anotherName = "Ahmed";
            int length = anotherName.Length;


            var population = 66_000_000;
            var weight = 1.88;
            var price = 4.99M;
            var fruit = "Apples";
            var letter = 'Z';
            var happy = true;

            Console.WriteLine($"default(int) = {default(int)}");
            Console.WriteLine($"default(bool) = {default(bool)}");
            Console.WriteLine($"default(DateTime) = {default(DateTime)}");
            Console.WriteLine($"default(string) = {default(string)}");

        }
    }
}
