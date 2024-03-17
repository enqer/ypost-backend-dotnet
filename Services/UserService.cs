using AutoMapper;
using ypost_backend_dotnet.Common;
using ypost_backend_dotnet.Entities;
using ypost_backend_dotnet.Exceptions;
using ypost_backend_dotnet.Models;

namespace ypost_backend_dotnet.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(AppDbContext appDbContext, IMapper mapper)
        {
            _dbContext = appDbContext;
            _mapper = mapper;
        }

        public User GetUserById(Guid id)
        {
            var u = _dbContext
                .Users
                .Where (u => u.Id == id)
                .FirstOrDefault();
            Console.WriteLine("vbibe6er");
            if (u == null)
                throw new NotFoundException("User does not exist");

            var res = _mapper.Map<UserDto>(u);
            Console.WriteLine("vbib" + res);
            return u;
        }
    }
}
