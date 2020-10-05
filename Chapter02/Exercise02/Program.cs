using System;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"{"Type",-10} {"Bytes(s)",-10} {"Min Value",-35} {"Max Value",-35}");
            Console.WriteLine($"{"sbyte",-10} {sizeof(sbyte),-10} {sbyte.MinValue,-35} {sbyte.MaxValue,-35}");
            Console.WriteLine($"{"byte",-10} {sizeof(byte),-10} {byte.MinValue,-35} {byte.MaxValue,-35}");
            Console.WriteLine($"{"short",-10} {sizeof(short),-10} {short.MinValue,-35} {short.MaxValue,-35}");
            Console.WriteLine($"{"ushort",-10} {sizeof(ushort),-10} {ushort.MinValue,-35} {ushort.MaxValue,-35}");
            Console.WriteLine($"{"int",-10} {sizeof(int),-10} {int.MinValue,-35} {int.MaxValue,-35}");
            Console.WriteLine($"{"uint",-10} {sizeof(uint),-10} {uint.MinValue,-35} {uint.MaxValue,-35}");
            Console.WriteLine($"{"long",-10} {sizeof(long),-10} {long.MinValue,-35} {long.MaxValue,-35}");
            Console.WriteLine($"{"ulong",-10} {sizeof(ulong),-10} {ulong.MinValue,-35} {ulong.MaxValue,-35}");
            Console.WriteLine($"{"float",-10} {sizeof(float),-10} {float.MinValue,-35} {float.MaxValue,-35}");
            Console.WriteLine($"{"double",-10} {sizeof(double),-10} {double.MinValue,-35} {double.MaxValue,-35}");
            Console.WriteLine($"{"decimal",-10} {sizeof(decimal),-10} {decimal.MinValue,-35} {decimal.MaxValue,-35}");

        }
    }
}
