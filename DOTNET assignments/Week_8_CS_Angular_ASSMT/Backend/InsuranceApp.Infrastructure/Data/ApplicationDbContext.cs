using Microsoft.EntityFrameworkCore;
using InsuranceApp.Domain.Entities;

namespace InsuranceApp.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Policy> Policies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // One-to-One: User and Customer Profile
        modelBuilder.Entity<Customer>()
            .HasOne(c => c.User)
            .WithOne(u => u.CustomerProfile)
            .HasForeignKey<Customer>(c => c.UserId)
            .IsRequired(false);

        // One-to-Many: Agent (User) and Customer
        modelBuilder.Entity<Customer>()
            .HasOne(c => c.Agent)
            .WithMany()
            .HasForeignKey(c => c.AgentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete if an agent is deleted

        // One-to-Many: Customer and Policies
        modelBuilder.Entity<Policy>()
            .HasOne(p => p.Customer)
            .WithMany(c => c.Policies)
            .HasForeignKey(p => p.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
