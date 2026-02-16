using Microsoft.EntityFrameworkCore;

namespace Week_7_CS_ASSMT.Models
{
    public class InsuranceContext : DbContext
    {
        public InsuranceContext(DbContextOptions<InsuranceContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
    }
}
