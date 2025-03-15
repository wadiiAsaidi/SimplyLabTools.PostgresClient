using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using TestDockerProject.Models;

namespace TestDockerProject.Configuration
{
    public class DbContextBase : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<State> States { get; set; }
        //public const string ConnectionString= "User ID=wadii;Password=12690241;Server=192.168.52.138;Port=5432;Database=mydatabase;Pooling=true;";
        public const string ConnectionString= "Host=192.168.52.138;Port=5432;Database=mydatabase;Username=wadii;Password=12690241;Trust Server Certificate=true";
        //"DefaultConnection": "Host=192.168.52.138;Port=5432;Database=mydatabase;Username=your-username;Password=your-password;Trust Server Certificate=true"


        public DbContextBase() : base(GetConnectionString(ConnectionString)) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.State)
                .WithMany()
                .HasForeignKey(c => c.StateId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);
        }
        private static DbContextOptions<DbContext> GetConnectionString(string connectionString)
        {
            var contextOptions = new DbContextOptionsBuilder<DbContext>()
                                       .UseNpgsql(connectionString).Options;
            return contextOptions;
        }
    }
}
