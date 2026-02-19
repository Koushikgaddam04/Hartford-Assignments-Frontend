using Day_35_C__InsurancePoliciesFullstack.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_35_C__InsurancePoliciesFullstack.Data
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options)
        {
        }

        // These DbSets represent your tables
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Policy> Policies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // You can add extra Fluent API configuration here if needed, 
            // but your Data Annotations already handle the basics!
        }
    }
}
