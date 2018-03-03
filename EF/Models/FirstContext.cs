using Microsoft.EntityFrameworkCore;
 
namespace EF.Models
{
    public class FirstContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public FirstContext(DbContextOptions<FirstContext> options) : base(options) { }
        public DbSet<Person> Users{get;set;}
    }
}
