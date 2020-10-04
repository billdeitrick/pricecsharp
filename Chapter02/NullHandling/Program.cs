#nullable enable

using System;

namespace NullHandling
{
    class Address
    {
        public string? Building = String.Empty;
        public string Street = String.Empty;
        public string City = String.Empty;
        public string Region = String.Empty;
    }

    class Program
    {
        static void Main(string[] args)
        {
            int thisCannotBeNull = 4;
            // thisCannotBeNull = null;

            int? thisCouldBeNull = null;
            Console.WriteLine(thisCouldBeNull);
            Console.WriteLine(thisCouldBeNull.GetValueOrDefault());
            thisCouldBeNull = 7;
            Console.WriteLine(thisCouldBeNull);
            Console.WriteLine(thisCouldBeNull.GetValueOrDefault());

            var address = new Address();
            address.Building = null;
            address.Street = null;
            address.City = "London";
            address.Region = null;
        }
    }
}
