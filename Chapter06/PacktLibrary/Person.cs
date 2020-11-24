using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using static System.Console;

namespace Packt.Shared
{
    public class Person : IComparable<Person>
    {

        public string Name;
        public DateTime DateOfBirth;

        public List<Person> children = new List<Person>();

        public event EventHandler Shout;

        public int AngerLevel;

        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                if (Shout != null)
                {
                    Shout(this, EventArgs.Empty);
                }
            }
        }

        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}");
        }

        public static Person Procreate(Person p1, Person p2)
        {
            var baby = new Person
            {
                Name = $"Baby of {p1.Name} and {p2.Name}"
            };
            p1.children.Add(baby);
            p2.children.Add(baby);

            return baby;
        }

        public Person ProCreateWith(Person partner)
        {
            return Procreate(this, partner);
        }

        public static Person operator *(Person p1, Person p2) {
            return Procreate(p1, p2);
        }

        public static int Factorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"{nameof(number)} cannot be less than zero.");
            }

            return localFactorial(number);

            int localFactorial(int localNumber)
            {
                if (localNumber < 1) return 1;
                return localNumber * localFactorial(localNumber - 1);
            }
        }

        public int CompareTo([AllowNull] Person other)
        {
            return Name.CompareTo(other.Name);
        }

        public void TimeTravel(DateTime when)
        {
            if (when <= DateOfBirth)
            {
                throw new PersonException("If you travel back in time to a date earlier than your own birth, then the universe will explode!");
            } else
            {
                WriteLine($"Welcome to {when:yyyy}!");
            }
        }
    }
}
