using Microsoft.EntityFrameworkCore;
using HealthTrackerService.Models;

namespace HealthTrackerService.Data
{
    public class HealthDbContext : DbContext
    {
        public HealthDbContext(DbContextOptions<HealthDbContext> options) : base(options) { }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MoodLog> MoodLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Seed data or configuration if needed
        }
    }
}
