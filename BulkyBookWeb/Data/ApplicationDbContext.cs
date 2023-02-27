using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Runtime.Intrinsics.X86;

namespace BulkyBookWeb.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product
                    {
                        Id = 1,
                        Title = "HDD 1TB",
                        Quantiy = 55,
                        Price = 74.09,
                    },
                    new Product
                    {
                        Id = 2,
                        Title = "HDD SSD 512GB",
                        Quantiy = 102,
                        Price = 190.99,
                    },
                    new Product
                    {
                        Id = 3,
                        Title = "RAM DDR4 16GB ",
                        Quantiy = 47,
                        Price = 80.32,
                    }
                );
        }
    }

}
