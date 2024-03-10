
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
        public ActionResult createPost([FromBody] CreatePostDto dto)
        {
            Console.WriteLine("tet");
            var res = postService.createPost(dto);
            return Created($"/api/v1/post/{res.Id}",null);
        }

        
    }
}
