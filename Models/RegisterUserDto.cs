using System.ComponentModel.DataAnnotations;
using ypost_backend_dotnet.Common;
using ypost_backend_dotnet.Entities;

namespace ypost_backend_dotnet.Models
{
    public class RegisterUserDto
    {
        [MinLength(5)]
        [MaxLength(25)]
        public string UserName { get; set; }
        [MaxLength(25)]
        public string FirstName { get; set; }
        [MaxLength(25)]
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string? Image { get; set; }
        [MaxLength(100)]
        public string? Bio { get; set; }
        public DateTime? BirthDate { get; set; }
        [MinLength(8)]
        public string Password { get; set; }
       
    }
}