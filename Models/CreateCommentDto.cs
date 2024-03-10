namespace ypost_backend_dotnet.Models
{
    public class CreateCommentDto
    {
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public Guid? EntryId { get; set; }
    }
}
