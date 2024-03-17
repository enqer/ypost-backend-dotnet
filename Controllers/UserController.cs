using Microsoft.AspNetCore.Mvc;
using ypost_backend_dotnet.Entities;
using ypost_backend_dotnet.Models;
using ypost_backend_dotnet.Services;

namespace ypost_backend_dotnet.Controllers
{
    [ApiController]
    [Route("/api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }


        [HttpGet("{id}")]
        public ActionResult<User> GetUserById([FromRoute] Guid id)
        {
            Console.WriteLine("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            User user = userService.GetUserById(id);
            return Ok(user);
        }
    }
}
