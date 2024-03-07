using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ypost_backend_dotnet.Common;
using ypost_backend_dotnet.Entities;
using ypost_backend_dotnet.Exceptions;
using ypost_backend_dotnet.Models;

namespace ypost_backend_dotnet.Services
{

    public interface IAuthService
    {
        string GenerateJwt(LoginDto dto);
        void RegisterUser(RegisterUserDto userDto);
    }

    public class AuthService : IAuthService
    {
        private readonly AppDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthSettings auth;

        public AuthService(AppDbContext appDbContext, IPasswordHasher<User> passwordHasher, AuthSettings auth) {
            _dbContext = appDbContext;
            _passwordHasher = passwordHasher;
            this.auth = auth;
        }

        public string GenerateJwt(LoginDto dto)
        {
            var user = _dbContext.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.UserName == dto.UserName);

            if (user == null)
            {
                throw new BadRequestException("Invalid username or password");
            }
            var result =_passwordHasher.VerifyHashedPassword(user, user.Password, dto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var claims = new List<Claim>()
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("UserName", $"{user.UserName}"),
                new Claim("Role", $"{user.Role.Name}"),
                new Claim("FirstName", $"{user.FirstName}"),
                new Claim("LastName", $"{user.LastName}"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(auth.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(auth.JwtExpireDays);

            var token = new JwtSecurityToken(
                    auth.JwtIssuer,
                    auth.JwtIssuer,
                    claims,
                    expires: expires,
                    signingCredentials: cred
                );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);

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
            _dbContext.SaveChanges();
        }
    }
}
