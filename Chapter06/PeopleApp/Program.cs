using System;
using Packt.Shared;
using static System.Console;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var harry = new Person { Name = "Harry" };
            var mary = new Person { Name = "Mary" };
            var jill = new Person { Name = "Jill" };

            var baby1 = mary.ProCreateWith(harry);
            var baby2 = Person.Procreate(harry, jill);
            var baby3 = harry * mary;

            WriteLine($"{harry.Name} has {harry.children.Count} children.");
            WriteLine($"{mary.Name} has {mary.children.Count} children.");
            WriteLine($"{jill.Name} has {jill.children.Count} children.");
            WriteLine($"{harry.Name}'s first child is named {harry.children[0].Name}");

            WriteLine($"5! is {Person.Factorial(5)}");

            harry.Shout += Harry_Shout;
            harry.Poke();
            harry.Poke();
            harry.Poke();
            harry.Poke();

            Person[] people =
            {
                new Person{ Name = "Simon" },
                new Person{ Name = "Jenny" },
                new Person{ Name = "Adam" },
                new Person{ Name = "Richard" }
            };

            WriteLine("Initial list of people.");
            foreach (var person in people)
            {
                WriteLine($"{person.Name}");
            }

            Array.Sort(people);

            WriteLine("Using Person class's CompareTo to sort.");
            foreach(var person in people)
            {
                WriteLine($"{person.Name}");
            }

            Array.Sort(people, new PersonComparer());

            WriteLine("Using Person class's Compare to sort.");
            foreach (var person in people)
            {
                WriteLine($"{person.Name}");
            }

            var t1 = new Thing();
            t1.Data = 42;
            WriteLine($"Thing with an integer: {t1.Process(42)}");

            var t2 = new Thing();
            t2.Data = "Apple";
            WriteLine($"Thing with a string: {t2.Process("Apple")}");

            var gt1 = new GenericThing<int>();
            gt1.Data = 42;
            WriteLine($"Generic thing with an integer: {gt1.Process(42)}");

            var gt2 = new GenericThing<string>();
            gt2.Data = "Apple";
            WriteLine($"Generic thing with a string: {gt2.Process("Apple")}");

            string number1 = "4";
            WriteLine("{0} squared is {1}",
                arg0: number1,
                arg1: Squarer.Square<string>(number1));

            byte number2 = 3;
            WriteLine("{0} squared is {1}",
                arg0: number2,
                arg1: Squarer.Square(number2));

            var dv1 = new DisplacementVector(3, 5);
            var dv2 = new DisplacementVector(-2, 7);
            var dv3 = dv1 + dv2;

            WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");

            Employee john = new Employee
            {
                Name = "John Jones",
                DateOfBirth = new DateTime(1990, 7, 28)
            };
            john.EmployeeCode = "JJ001";
            john.HireDate = new DateTime(2014, 11, 23);
            john.WriteToConsole();

            WriteLine($"{john.Name} was hired on {john.HireDate: dd/MM/yy}");
            WriteLine(john.ToString());

            Employee aliceInEmployee = new Employee
            {
                Name = "Alice",
                EmployeeCode = "AA123"
            };
            Person aliceInPerson = aliceInEmployee;

            aliceInEmployee.WriteToConsole();
            aliceInPerson.WriteToConsole();
            WriteLine(aliceInEmployee.ToString());
            WriteLine(aliceInPerson.ToString());

            if (aliceInPerson is Employee) {
                WriteLine($"{nameof(aliceInPerson)} IS an Employee");
                Employee explicitAlice = (Employee)aliceInPerson;
            }

            Employee aliceAsEmployee = aliceInPerson as Employee;

            if (aliceAsEmployee != null)
            {
                WriteLine($"{nameof(aliceInPerson)} AS an Employee");
            }

            try
            {
                john.TimeTravel(new DateTime(1999, 12, 31));
                john.TimeTravel(new DateTime(1950, 12, 25));
            } catch (PersonException ex)
            {
                WriteLine(ex.Message);
            }

            string email1 = "pamela@test.com";
            string email2 = "ian&test.com";
            WriteLine($"{email1} is a valid email address: {email1.IsValidEmail()}");
            WriteLine($"{email2} is a valid email address: {email2.IsValidEmail()}");

        }

        private static void Harry_Shout(object sender, EventArgs e)
        {
            Person p = (Person)sender;
            WriteLine($"{p.Name} is this angry: {p.AngerLevel}");
        }
    }
}
