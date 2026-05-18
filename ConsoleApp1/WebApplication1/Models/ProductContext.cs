using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasQueryFilter(s => !s.IsDeleted);
            modelBuilder.Entity<OrderItems>()
       .HasKey(oi => new { oi.OrderId, oi.ProductId });

        }
    }
}
