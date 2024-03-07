using Microsoft.AspNetCore.Identity;
using ypost_backend_dotnet.Common;
using ypost_backend_dotnet.Entities;
using ypost_backend_dotnet.Models;

namespace ypost_backend_dotnet.Services
{

    public interface IAuthService
    {
        void RegisterUser(RegisterUserDto userDto);
    }

    public class AuthService : IAuthService
    {
        private readonly AppDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(AppDbContext appDbContext, IPasswordHasher<User> passwordHasher) {
            _dbContext = appDbContext;
            _passwordHasher = passwordHasher;
        }

        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                UserName = dto.UserName,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Image = dto.Image,
                Bio = dto.Bio,
                BirthDate = dto.BirthDate,
                JoinedOn = DateTime.UtcNow.AddHours(1),
                Password = dto.Password,
                RoleId = (int)RoleType.User

            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.Password = hashedPassword;
            _dbContext.Users.Add(newUser);
        }
    }
}
