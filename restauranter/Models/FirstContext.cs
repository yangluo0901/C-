using Microsoft.EntityFrameworkCore;
 
namespace restauranter.Models
{
    public class FirstContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public FirstContext(DbContextOptions<FirstContext> options) : base(options) { }
        
        public DbSet<View> views{get;set;}
        
    }
}
