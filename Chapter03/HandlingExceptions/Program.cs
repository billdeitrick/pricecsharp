using System;
using static System.Console;

namespace HandlingExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Before parsing");
            WriteLine("What is your age? ");
            string input = ReadLine();

            try
            {
                int age = int.Parse(input);
                WriteLine($"You are {age} year(s) old.");
            }
            catch (FormatException)
            {
                WriteLine("The age you entered is not a valid number format.");
            }
            catch (OverflowException)
            {
                WriteLine("Your age is a valid number format but it is either too large or too small.");
            }
            catch (Exception ex) {

                WriteLine($"{ex.GetType()} says {ex.Message}");
            
            }

            WriteLine("After parsing.");
        }
    }
}
