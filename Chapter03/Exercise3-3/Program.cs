using System;
using static System.Console;

namespace Exercise3_3
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 1; i <= 100; i++)
            {

                if (i % 3 == 0 & i % 5 == 0)
                {
                    Write("fizbuzz, ");
                }
                else if (i % 3 == 0)
                {
                    Write("fizz, ");
                }
                else if (i % 5 == 0)
                {
                    Write("buzz, ");
                } else
                {
                    Write($"{i}, ");
                }

                if (i % 10 == 0)
                {
                    WriteLine();
                }

            }

        }
    }
}
