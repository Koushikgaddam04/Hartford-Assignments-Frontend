using Insurance.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Policy> Policies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define Relationship: One Customer has Many Policies
        modelBuilder.Entity<Policy>()
            .HasOne(p => p.User)
            .WithMany(u => u.Policies)
            .HasForeignKey(p => p.UserId);

        modelBuilder.Entity<Policy>()
        .Property(p => p.Premium)
        .HasColumnType("decimal(18,2)");

        // Self-referencing relationship: Admin assigns an Agent (User) to a Customer (User)
        modelBuilder.Entity<User>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(u => u.AssignedAgentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}