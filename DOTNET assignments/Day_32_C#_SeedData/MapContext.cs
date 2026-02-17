using Day_32_C__SeedData.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_32_C__SeedData
{
    public class MapContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuring the database connection
            optionsBuilder.UseSqlServer(@"Data Source=KOUSHIK;Database=MAPDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Countries Master Data
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, CountryName = "India", CountryCode = "IND" },
                new Country { CountryId = 2, CountryName = "Australia", CountryCode = "AUS" }
            );
            // Seed States Master Data
            modelBuilder.Entity<State>().HasData(
                new State { StateId = 1, StateName = "Odisha", CountryId = 1 },
                new State { StateId = 2, StateName = "Delhi", CountryId = 1 },
                new State { StateId = 3, StateName = "New South Wales", CountryId = 2 }
            );
            // Seed Cities Master Data
            modelBuilder.Entity<City>().HasData(
                new City { CityId = 1, CityName = "Bhubaneswar", StateId = 1 },
                new City { CityId = 2, CityName = "Cuttack", StateId = 1 },
                new City { CityId = 3, CityName = "New Delhi", StateId = 2 },
                new City { CityId = 4, CityName = "Sydney", StateId = 3 }
            );
        }
        // DbSets representing the tables
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}