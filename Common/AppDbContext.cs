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
                u.Property(u => u.UserName).HasMaxLength(25);
                u.Property(u => u.FirstName).HasMaxLength(25);
                u.Property(u => u.LastName).HasMaxLength(25);
                u.Property(u => u.JoinedOn).HasDefaultValue(DateTime.UtcNow.AddHours(1));
                u.HasMany(u => u.Posts).WithOne(e => e.Author).HasForeignKey(k => k.AuthorId);
            });

            modelBuilder.Entity<Entry>(e =>
            {
                e.Property(e => e.Content).HasMaxLength(160);
                e.Property(e => e.CreatedOn).HasDefaultValue(DateTime.UtcNow.AddHours(1));
                e.Property(e => e.Likes).HasDefaultValue(0);
            });
        }
    }
}
