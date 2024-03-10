using ypost_backend_dotnet.Common;
using ypost_backend_dotnet.Entities;
using ypost_backend_dotnet.Models;

namespace ypost_backend_dotnet.Services
{

    public interface IPostService
    {
        Entry createPost(CreatePostDto dto);
    }

    public class PostService : IPostService
    {
    
        private readonly AppDbContext _dbContext;

        public PostService(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public Entry createPost(CreatePostDto dto)
        {
            var post = new Entry()
            {
                Content = dto.Content,
                CreatedOn = DateTime.UtcNow.AddHours(1),
                Likes = 0,
                AuthorId = dto.AuthorId,

            };
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
            return post;
        }
    }
}
