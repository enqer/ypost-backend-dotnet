using ypost_backend_dotnet.Common;

namespace ypost_backend_dotnet.Services
{
    public class UserService
    {
        private readonly AppDbContext _dbContext;

        public UserService(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
    }
}
