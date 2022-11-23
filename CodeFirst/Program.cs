using Microsoft.EntityFrameworkCore;

namespace CodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --> Kod ile migration islemi
            //ECommerceDemoDbContext context = new ECommerceDemoDbContext();
            //await context.Database.MigrateAsync();
        }
    }

    public class ECommerceDemoDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ECommerceDemo;User Id=ofarukcan;Password=prostreet273;TrustServerCertificate=True;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}