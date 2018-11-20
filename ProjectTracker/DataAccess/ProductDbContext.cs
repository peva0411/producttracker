using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectTracker.Model;

namespace ProjectTracker.DataAccess
{
    public class ProductDbContext : DbContext
    {
      public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
      {
        
      }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Product>().ToTable("Product");
      modelBuilder.Entity<Client>().ToTable("Client");
      modelBuilder.Entity<ClientProduct>().ToTable("ClientProduct");
      modelBuilder.Entity<ProductPrice>().ToTable("ProductPrice");

    }

    public DbSet<Product> Products { get; set; }
      public DbSet<Client> Clients { get; set; }
      public DbSet<ClientProduct> ClientProducts { get; set; }
      public DbSet<ProductPrice> ProductPrices { get; set; }
    }
}
