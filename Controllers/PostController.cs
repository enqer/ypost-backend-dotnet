
using Microsoft.AspNetCore.Mvc;
using ypost_backend_dotnet.Services;

namespace ypost_backend_dotnet.Controllers
{

    [Route("/api/v1/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostService postService;

        public PostController(PostService postService) 
        {
            this.postService = postService;
        }


        [HttpPost]
        public ActionResult createPost()
        {

            return Created($"eqw",null);
        }
    }
}
