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
        public DbSet<Entry> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.Property(u => u.Username).HasMaxLength(25);
                u.Property(u => u.FirstName).HasMaxLength(25);
                u.Property(u => u.LastName).HasMaxLength(25);
            });
        }
    }
}
