using Microsoft.EntityFrameworkCore;

namespace Day_32_C_.Models
{
    public class InsuranceContext : DbContext
    {
        // This constructor allows the connection string from Program.cs to be passed in
        public InsuranceContext(DbContextOptions<InsuranceContext> options) : base(options)
        {
        }

        // These properties represent your tables in SQL Server
        public DbSet<Customer> Customers { get; set; }
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }

        // Optional: Fluent API to ensure the relationship is explicit
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Policies)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerId);
        }


    }
}