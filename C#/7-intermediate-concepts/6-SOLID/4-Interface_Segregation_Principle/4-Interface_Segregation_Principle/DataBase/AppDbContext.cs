using _4_Interface_Segregation_Principle.Entities;
using Microsoft.EntityFrameworkCore;

namespace _4_Interface_Segregation_Principle.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Activity> Activity { get; set; }
    }
}
