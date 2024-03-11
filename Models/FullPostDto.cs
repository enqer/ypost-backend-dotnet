using ypost_backend_dotnet.Entities;

namespace ypost_backend_dotnet.Models
{
    public class FullPostDto
    {
        public Guid Id { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int Likes { get; set; }
        public required UserMinimalDto Author { get; set; }
        public List<PostDto> Comments { get; set; } = new List<PostDto>();
    }
}
