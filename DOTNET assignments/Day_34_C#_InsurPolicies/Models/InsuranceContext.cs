using Microsoft.EntityFrameworkCore;

namespace Day_34_C__InsurPolicies.Models
{
    public class InsuranceContext : DbContext
    {
        public InsuranceContext(DbContextOptions<InsuranceContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This ensures your PremiumAmount doesn't lose decimal places in SQL Server
            modelBuilder.Entity<InsurancePolicy>()
                .Property(p => p.PremiumAmount)
                .HasColumnType("decimal(18,2)");

            // Defining the relationship: One Customer has many Policies
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Policies)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerId);
        }
    }
}