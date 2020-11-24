using System;
using static System.Console;
using Packt.Shared;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bob = new Person();
            bob.Name = "Bob Smith";
            bob.DateOfBirth = new DateTime(1965, 12, 22);
            WriteLine($"{bob.Name} was born on {bob.DateOfBirth:dddd, d MMMM yyyy}");

            bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
            WriteLine($"{bob.Name}'s favorite wonder is {bob.FavoriteAncientWonder}. Its integer is {(int)bob.FavoriteAncientWonder}.");

            bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon
                | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;

            WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");

            bob.Children.Add(new Person { Name = "Alfred" });
            bob.Children.Add(new Person { Name = "Zoe" });

            WriteLine($"{bob.Name} has {bob.Children.Count} children:");
            foreach (Person child in bob.Children)
            {
                WriteLine($"    {child.Name}");
            }

            WriteLine($"{bob.Name} is of species {Person.Species}");
            WriteLine($"{bob.Name} was born on planet {bob.HomePlanet}");

            bob.WriteToConsole();
            WriteLine(bob.GetOrigin());
            (string, int) fruit = bob.GetFruit();
            WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");
            var fruitNamed = bob.GetNamedFruit();
            WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");

            var thing1 = ("Neville", 4);
            WriteLine($"{thing1.Item1} has {thing1.Item2} children.");
            var thing2 = (bob.Name, bob.Children.Count);
            WriteLine($"{thing2.Name} has {thing2.Count} children.");

            (string fruitName, int fruitNumber) = bob.GetFruit();
            WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");

            var alice = new Person
            {
                Name = "Alice Jones",
                DateOfBirth = new DateTime(1998, 3, 7)
            };
            WriteLine($"{alice.Name} was born on {alice.DateOfBirth:dd MMM yy}");

            BankAccount.InterestRate = 0.012M;
            var jonesAccount = new BankAccount();

            jonesAccount.AccountName = "Mrs. Jones";
            jonesAccount.Balance = 2400;
            WriteLine($"{jonesAccount.AccountName} earned {jonesAccount.Balance * BankAccount.InterestRate:C} interest.");

            var gerrierAccount = new BankAccount();
            gerrierAccount.AccountName = "Ms. Gerrier";
            gerrierAccount.Balance = 98;
            WriteLine($"{gerrierAccount.AccountName} earned {gerrierAccount.Balance * BankAccount.InterestRate:C}");

            var blankPerson = new Person();
            WriteLine($"{blankPerson.Name} of {blankPerson.HomePlanet} was created at {blankPerson.Instantiated:hh:mm:ss} on a {blankPerson.Instantiated:dddd}");

            var gunny = new Person("Gunny", "Mars");
            WriteLine($"{gunny.Name} of {gunny.HomePlanet} was created at {gunny.Instantiated:hh:mm:ss} on a {gunny.Instantiated:dddd}");

            WriteLine(bob.SayHello());
            WriteLine(bob.SayHello("Emily"));

            WriteLine(bob.OptionalParameters());
            WriteLine(bob.OptionalParameters("Jump", 98.5));
            WriteLine(bob.OptionalParameters(number: 52.7, command: "Hide!"));
            WriteLine(bob.OptionalParameters("Poke", active: false));

            int a = 10;
            int b = 20;
            int c = 30;
            WriteLine($"Before: a = {a}, b = {b}, c = {c}");
            bob.PassingParameters(a, ref b, out c);
            WriteLine($"After: a = {a}, b = {b}, c = {c}");

            int d = 10;
            int e = 20;
            WriteLine($"Before: d = {d}, e = {e}, f doesn't exist yet!");
            bob.PassingParameters(d, ref e, out int f);
            WriteLine($"After: d = {d}, e = {e}, f = {f}!");

            var sam = new Person
            {
                Name = "Sam",
                DateOfBirth = new DateTime(1972, 1, 27)
            };
            WriteLine(sam.Origin);
            WriteLine(sam.Greeting);
            WriteLine(sam.Age);

            sam.FavoriteIceCream = "Chocolage Fudge";
            WriteLine($"Sam's favorite ice cream flavor is {sam.FavoriteIceCream}");
            sam.FavoritePrimaryColor = "red";
            WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}");

            sam.Children.Add(new Person { Name = "Charlie" });
            sam.Children.Add(new Person { Name = "Ella" });

            WriteLine($"Sam's first child is {sam.Children[0].Name}");
            WriteLine($"Sam's second child is {sam.Children[0].Name}");
            WriteLine($"Sam's first child is {sam[0].Name}");
            WriteLine($"Sam's second child is {sam[1].Name}");

        }
    }
}
