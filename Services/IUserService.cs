using ypost_backend_dotnet.Entities;
using ypost_backend_dotnet.Models;

namespace ypost_backend_dotnet.Services
{
    public interface IUserService
    {
        User GetUserById(Guid id);
    }
}