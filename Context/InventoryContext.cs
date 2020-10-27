using System;
using CapstoneWk4ShoppingList.Models;
using Microsoft.EntityFrameworkCore;

namespace CapstoneWk4ShoppingList.Context
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {

        }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=Inventory;User=sa;Password=Cornflake7!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName).HasColumnName("Name");
                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.Price).HasColumnName("Price");
                entity.Property(e => e.Price).IsRequired();
            });
            modelBuilder.Entity<Products>().HasData(
                new Products { ProductId = 1, ProductName = "Geometry for Dummies", Price = 39.99M },
                new Products { ProductId = 2, ProductName = "Algebra for Dummies", Price = 29.99M },
                new Products { ProductId = 3, ProductName = "Calculus for Dummies", Price = 49.99M }
                );
        }
       
    }
}
