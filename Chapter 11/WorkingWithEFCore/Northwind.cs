using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

namespace Packt.Shared
{
    public class Northwind : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        private string DBPath;

        public Northwind(string dbPath)
        {
            DBPath = dbPath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DBPath}");
            //optionsBuilder.UseLazyLoadingProxies()
                //.UseSqlite($"Filename={DBPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => !p.Discontinued);
        }

    }
}
