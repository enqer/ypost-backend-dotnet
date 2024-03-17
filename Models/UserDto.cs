using ypost_backend_dotnet.Entities;

namespace ypost_backend_dotnet.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Image { get; set; }
        public string? Bio { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime JoinedOn { get; set; }

    }
}
