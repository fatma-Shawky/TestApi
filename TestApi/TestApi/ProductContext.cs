using Microsoft.Extensions.Options;
using System.Collections.Generic;
using TestApi.Models;
using TestApi;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace TestApi
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {}
       
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}