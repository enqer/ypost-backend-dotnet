using ypost_backend_dotnet.Entities;

namespace ypost_backend_dotnet.Models
{
    public class UserMinimalDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Image { get; set; }
        public string? Bio { get; set; }

    }
}
