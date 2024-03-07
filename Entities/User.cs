using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ypost_backend_dotnet.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string? Image { get; set; }
        public string? Bio { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime JoinedOn { get; set; }
        public List<Entry> Posts { get; set; } = new List<Entry>();
        public string Password { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
