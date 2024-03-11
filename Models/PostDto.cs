using System.ComponentModel.DataAnnotations;
using ypost_backend_dotnet.Entities;

namespace ypost_backend_dotnet.Models
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int Likes { get; set; }
        public UserMinimalDto Author { get; set; }
        public int NumOfComments { get; set; }
    }
}
