
using ypost_backend_dotnet.Entities;

namespace ypost_backend_dotnet.Common
{
    public class Seeder
    {
        private readonly AppDbContext _dbContext;

        public Seeder(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect()) 
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
            }
        }

        private List<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "Admin",
                },
                new Role()
                {
                    Name = "User"
                }
            };
            return roles;
        }
    }
}
