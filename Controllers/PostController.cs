
using Microsoft.AspNetCore.Mvc;
using ypost_backend_dotnet.Entities;
using ypost_backend_dotnet.Models;
using ypost_backend_dotnet.Services;

namespace ypost_backend_dotnet.Controllers
{

    [Route("/api/v1/post")]
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
            return Created($"/api/v1/post/{res.Id}",null);
        }

        [HttpPost("{id}/thread")]
        public ActionResult CreateThread([FromRoute] Guid id, [FromBody] CreatePostDto dto)
        {

            Entry res = postService.CreateThread(id, dto);

            return Created($"/api/v1/post/{id}/thread/{res.Id}", null);
        }

        [HttpPost("{id}/like")]
        public ActionResult AddLikeToPost([FromRoute] Guid id)
        {
            postService.AddLikeToPost(id);
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
