using Microsoft.EntityFrameworkCore;

namespace Wedding_planner.Models
{
    public class WeddingContext:DbContext
    {
        public WeddingContext(DbContextOptions<WeddingContext> options):base(options){}
        public DbSet<Person> users {get;set;}
        public DbSet<Wedding> weddings {get;set;}
        public DbSet<Join> joins {get;set;}
    }
}