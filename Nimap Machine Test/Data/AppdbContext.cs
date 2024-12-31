using Microsoft.EntityFrameworkCore;
using Nimap_Machine_Test.Models;

namespace Nimap_Machine_Test.Data
{
    public class AppdbContext : DbContext
    {
        //Constructor
        public AppdbContext(DbContextOptions<AppdbContext> options) : base(options)
        {
        }

        //DbSet properties
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade); // Ensure Cascade Delete
        }
    }
}
