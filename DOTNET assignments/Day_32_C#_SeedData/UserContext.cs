using Day_32_C__SeedData.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_32_C__SeedData
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
