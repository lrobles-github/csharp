using Microsoft.EntityFrameworkCore;
 
namespace ecommerce.Models
{
    public class ecommerceContext : DbContext
    {
        public ecommerceContext(DbContextOptions<ecommerceContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}