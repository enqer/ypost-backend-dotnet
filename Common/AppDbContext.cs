using Microsoft.EntityFrameworkCore;
using ypost_backend_dotnet.Entities;

namespace ypost_backend_dotnet.Common
{
    public class AppDbContext : DbContext
    {
       
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
            
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
