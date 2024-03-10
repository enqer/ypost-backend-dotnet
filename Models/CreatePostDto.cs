using ypost_backend_dotnet.Entities;

namespace ypost_backend_dotnet.Models
{
    public class CreatePostDto
    {
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
    }
}
