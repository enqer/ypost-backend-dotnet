using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ypost_backend_dotnet.Common;
using ypost_backend_dotnet.Entities;
using ypost_backend_dotnet.Models;

namespace ypost_backend_dotnet.Services
{

    public interface IPostService
    {
        Entry CreatePost(CreatePostDto dto);
        List<PostDto> GetPosts();
    }

    public class PostService : IPostService
    {
    
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public PostService(AppDbContext appDbContext, IMapper mapper)
        {
            _dbContext = appDbContext;
            _mapper = mapper;
        }

        public Entry CreatePost(CreatePostDto dto)
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

        public List<PostDto> GetPosts()
        {
            var posts = _dbContext
                .Posts
                .Where(x => x.EntryId == null)
                .Include(x => x.Author)
                .ToList();

            var results = _mapper.Map<List<PostDto>>(_dbContext.Posts);

            return results;
        }
    }
}
