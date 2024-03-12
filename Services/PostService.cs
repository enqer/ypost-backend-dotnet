using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ypost_backend_dotnet.Common;
using ypost_backend_dotnet.Entities;
using ypost_backend_dotnet.Exceptions;
using ypost_backend_dotnet.Models;

namespace ypost_backend_dotnet.Services
{

    public interface IPostService
    {
        Entry CreatePost(CreatePostDto dto);
        public Entry CreateThread(Guid id, CreatePostDto dto);
        List<PostDto> GetPosts();
        public FullPostDto GetPostById(Guid id);
        void AddLikeToPost(Guid id);
        void UpdatePost(Guid id, UpdatePostDto content);
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

        public void AddLikeToPost(Guid id)
        {
            var post = _dbContext
                .Posts
                .Where(x => x.Id == id)
                .SingleOrDefault();

            if (post == null)
                throw new NotFoundException("Post doesn't exist");

            post.Likes += 1;
            _dbContext.SaveChanges();
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

        public Entry CreateThread(Guid id, CreatePostDto dto)
        {
            var post = new Entry()
            {
                Content = dto.Content,
                CreatedOn = DateTime.UtcNow.AddHours(1),
                Likes = 0,
                AuthorId = dto.AuthorId,
                EntryId = id,

            };

            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
            return post;
        }


        public FullPostDto GetPostById(Guid id)
        {
            var post = _dbContext
                .Posts
                .Where(x => x.Id == id)
                .Include(x => x.Author)
                .Include(x => x.Comments)
                .SingleOrDefault();

            var comments = _dbContext
                .Posts
                .Where(x => x.EntryId == id)
                .Include(x => x.Author)
                .Include(x => x.Comments)
                .ToList();

            var resCom = _mapper.Map<List<PostDto>>(comments);
            var results = _mapper.Map<FullPostDto>(post);
            results.Comments = resCom;

            return results;
        }

        public List<PostDto> GetPosts()
        {
            var posts = _dbContext
                .Posts
                .Where(x => x.EntryId == null)
                .Include(x => x.Author)
                .Include(x => x.Comments)
                .ToList();

            var results = _mapper.Map<List<PostDto>>(posts);

            return results;
        }

        public void UpdatePost(Guid id,[FromBody] UpdatePostDto dto)
        {
            var post = _dbContext
                .Posts
                .Where(x => x.Id == id)
                .SingleOrDefault();

            if (post == null)
                throw new NotFoundException("Post doesn't exist");
            
            post.Content = dto.Content;
            post.UpdatedOn = DateTime.Now.AddHours(1);
            _dbContext.SaveChanges();
        }
    }
}
