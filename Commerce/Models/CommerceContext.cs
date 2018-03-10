using Microsoft.EntityFrameworkCore;

namespace Commerce.Models
{
    public class CommerceContext : DbContext
    {
        public CommerceContext(DbContextOptions<CommerceContext> options) : base(options){}
        public DbSet<Customer> customers {get;set;}
        public DbSet<Product> products {get;set;}
        public DbSet<Order> orders {get;set;}
        public DbSet<Image> images {get;set;}
    }
}