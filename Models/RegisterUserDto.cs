using System.ComponentModel.DataAnnotations;
using ypost_backend_dotnet.Common;
using ypost_backend_dotnet.Entities;

namespace ypost_backend_dotnet.Models
{
    public class RegisterUserDto
    {

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string? Image { get; set; }
        public string? Bio { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Password { get; set; }
       
    }
}