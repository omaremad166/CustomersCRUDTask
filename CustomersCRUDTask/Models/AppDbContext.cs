using Microsoft.EntityFrameworkCore;

namespace CustomersCRUDTask.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-UD2P0IT\MY_INSTANCE;Database=CustomersCRUDTaskDb;Trusted_Connection=True;");
        }
    }
}
