namespace ypost_backend_dotnet.Entities
{
    public class Entry
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set;}
        public int Likes { get; set; }
        public User Author { get; set; }
        public Guid AuthorId { get; set; }
        public List<Entry> Comments { get; set; } = new List<Entry>();
        public Guid? EntryId { get; set; }

    }
}
