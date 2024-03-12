
using Microsoft.AspNetCore.Mvc;
using ypost_backend_dotnet.Entities;
using ypost_backend_dotnet.Models;
using ypost_backend_dotnet.Services;

namespace ypost_backend_dotnet.Controllers
{

    [Route("/api/v1/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;

        public PostController(IPostService postService) 
        {
            this.postService = postService;
        }


        [HttpPost]
        public ActionResult CreatePost([FromBody] CreatePostDto dto)
        {
            var res = postService.CreatePost(dto);
            return Created($"/api/v1/posts/{res.Id}",null);
        }

        [HttpPost("{id}/threads")]
        public ActionResult CreateThread([FromRoute] Guid id, [FromBody] CreatePostDto dto)
        {

            Entry res = postService.CreateThread(id, dto);

            return Created($"/api/v1/posts/{id}/threads/{res.Id}", null);
        }

        [HttpPost("{id}/likes")]
        public ActionResult AddLikeToPost([FromRoute] Guid id)
        {
            postService.AddLikeToPost(id);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult UpdatePost([FromRoute] Guid id, [FromBody] UpdatePostDto dto)
        {
            postService.UpdatePost(id, dto);
            return NoContent();
        }


        [HttpGet]
        public ActionResult<List<PostDto>> GetPosts()
        {
            var posts = postService.GetPosts();

            return Ok(posts);
        }

        [HttpGet("{id}")]
        public ActionResult<FullPostDto> GetPostById([FromRoute] Guid id)
        {
            FullPostDto res = postService.GetPostById(id);

            return Ok(res);
        }
    }
}
