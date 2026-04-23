using _5_Dependency_Inversion_principle.Entities;
using Microsoft.EntityFrameworkCore;

namespace _5_Dependency_Inversion_principle.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

       public DbSet<User> Users { get; set; }
       public DbSet<Log> Logs { get; set; }
    }
}
