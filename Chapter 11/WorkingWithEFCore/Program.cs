using System;
using static System.Console;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage;

namespace WorkingWithEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Northwind(args[0]))
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                //QueryCategories(db);
                //QueryingProducts(db);
                //QueryingWithLike(db);

                //if (AddProduct(db, 6, "Bob's Burgers", 500M))
                //{
                //    WriteLine("Add product successful.");
                //}

                //if (IncreaseProductPrice(db, "Bob", 20M))
                //{
                //    WriteLine("Update product price successful.");
                //}

                int deleted = DeleteProducts(db, "Bob");
                WriteLine($"{deleted} product(s) were deleted.");

                ListProducts(db);
            }
        }

        static void QueryingWithLike(Northwind db)
        {
            Write("Enter part of a product name:");
            string input = ReadLine();
            IQueryable<Product> prods = db.Products
                .Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));

            foreach(Product item in prods)
            {
                WriteLine("{0} has {1} units in stock. Discontinued? {2}",
                    item.ProductName, item.Stock, item.Discontinued);
            }
        }

        static void QueryCategories(Northwind db)
        {
            WriteLine("Categories and how many products they have:");

            IQueryable<Category> cats; // = db.Categories;
            //.Include(c => c.Products);

            db.ChangeTracker.LazyLoadingEnabled = false;

            Write("Enable eager loading? (Y/N): ");
            bool eagerLoading = (ReadKey().Key == ConsoleKey.Y);
            bool explicitLoading = false;

            if (eagerLoading)
            {
                cats = db.Categories.Include(c => c.Products);
            } else
            {
                cats = db.Categories;
                Write("Enable explicit loading? (Y/N): ");
                explicitLoading = (ReadKey().Key == ConsoleKey.Y);
                WriteLine();
            }

            foreach(Category c in cats)
            {
                if (explicitLoading)
                {
                    Write($"Explicitly load products for {c.CategoryName}?");
                    ConsoleKeyInfo key = ReadKey();
                    WriteLine();
                    if (key.Key == ConsoleKey.Y)
                    {
                        var products = db.Entry(c).Collection(c2 => c2.Products);
                        if (!products.IsLoaded) products.Load();
                    }
                }
                WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
            }
        }

        static void QueryingProducts(Northwind db)
        {
            WriteLine("Products that cost more than a price, highest on top.");

            string input;
            decimal price;

            do
            {
                Write("Enter product price: ");
                input = ReadLine();
            } while (!decimal.TryParse(input, out price));

            IOrderedEnumerable<Product> prods = db.Products
                .TagWith("Products filtered by price and sorted.")
                .AsEnumerable()
                .Where(product => product.Cost > price)
                .OrderByDescending(product => product.Cost);

            foreach(Product item in prods)
            {
                WriteLine(
                    "{0}: {1} costs {2:$#,##0.00} and has {3} in stock",
                    item.ProductID,
                    item.ProductName,
                    item.Cost,
                    item.Stock
                );
            }
        }

        static bool AddProduct(Northwind db, int categoryID, string productName, decimal? price)
        {
            var newProduct = new Product
            {
                CategoryID = categoryID,
                ProductName = productName,
                Cost = price
            };

            db.Products.Add(newProduct);

            int affected = db.SaveChanges();

            return (affected == 1);
        }

        static void ListProducts(Northwind db)
        {
            WriteLine("{0,-3} {1,-35}, {2,8}, {3,5}, {4}",
                "ID", "Product Name", "Cost", "Stock", "Disc."
            );

            foreach(var item in db.Products.ToList().OrderByDescending(p => p.Cost))
            {
                WriteLine("{0:000} {1,-35} {2,8:$#,##0.00} {3,5} {4}",
                    item.ProductID, item.ProductName, item.Cost,
                    item.Stock, item.Discontinued);
            }
        }

        static bool IncreaseProductPrice(Northwind db, string name, decimal amount)
        {
            Product updateProduct = db.Products.First(p => p.ProductName.StartsWith(name));
            updateProduct.Cost += amount;

            int affected = db.SaveChanges();
            return (affected == 1);
        }

        static int DeleteProducts(Northwind db, string name)
        {

            using (IDbContextTransaction t = db.Database.BeginTransaction())
            {
                WriteLine("Transaction isolation level: {0}",
                    t.GetDbTransaction().IsolationLevel);

                IEnumerable<Product> products = db.Products
                    .Where(p => p.ProductName.StartsWith(name));
                db.Products.RemoveRange(products);

                int affected = db.SaveChanges();
                t.Commit();
                return affected;
            }
        }
    }
}
