
using Microsoft.AspNetCore.Mvc;
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
            Console.WriteLine("tet");
            var res = postService.CreatePost(dto);
            return Created($"/api/v1/post/{res.Id}",null);
        }


        [HttpGet]
        public ActionResult<List<PostDto>> GetPosts()
        {
            var posts = postService.GetPosts();

            return Ok(posts);
        }
    }
}
