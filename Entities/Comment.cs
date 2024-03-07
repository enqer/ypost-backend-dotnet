namespace ypost_backend_dotnet.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int Likes { get; set; }
        public User Author { get; set; }
        public Guid AuthorId { get; set; }

    }
}
