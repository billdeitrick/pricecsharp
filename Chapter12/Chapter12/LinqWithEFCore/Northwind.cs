using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace LinqWithEFCore
{
    class Northwind : DbContext
    {

        private string DbPath;

        public Northwind(string DbPath)
        {
            this.DbPath = DbPath;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DbPath}");
        }

    }
}
