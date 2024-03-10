using ypost_backend_dotnet.Common;

namespace ypost_backend_dotnet.Services
{
    public class PostService
    {
        private readonly AppDbContext _dbContext;

        public PostService(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
    }
}
