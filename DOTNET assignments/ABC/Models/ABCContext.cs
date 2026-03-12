using Microsoft.EntityFrameworkCore;

namespace ABC.Models
{
    public class ABCContext : DbContext
    {
        public ABCContext(DbContextOptions<ABCContext> options) : base(options)
        {
            
        }

        public DbSet<ABCClass> ABCClasses { get; set; } = null!;
    }
}
