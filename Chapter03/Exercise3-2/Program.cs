using System;
using static System.Console;

namespace Exercise3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            checked
            {

                int max = 500;
                for (byte i = 0; i < max; i++)
                {
                    WriteLine(i);
                }

            }
        }
    }
}
