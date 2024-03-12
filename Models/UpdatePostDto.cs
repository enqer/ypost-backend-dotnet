using System.ComponentModel.DataAnnotations;

namespace ypost_backend_dotnet.Models
{
    public class UpdatePostDto
    {
        [Required]
        [MinLength(1)]
        [MaxLength(160)]
        public string Content { get; set; }
    }
}
