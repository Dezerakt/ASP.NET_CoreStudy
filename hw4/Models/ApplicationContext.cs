using Microsoft.EntityFrameworkCore;

namespace hw4.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=itemDB;Username=postgres;Password=postgres");
        }

    }
}
