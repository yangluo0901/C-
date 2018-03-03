using Microsoft.EntityFrameworkCore;

namespace Bank.Models
{
    public class BankContext:DbContext
    {
        public  BankContext(DbContextOptions<BankContext> options ) :base(options){}
        public DbSet<Person> users{get;set;}
        public DbSet<Action> actions {get;set;}
    }
}