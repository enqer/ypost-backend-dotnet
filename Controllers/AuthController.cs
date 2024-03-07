using Microsoft.AspNetCore.Mvc;
using ypost_backend_dotnet.Models;
using ypost_backend_dotnet.Services;

namespace ypost_backend_dotnet.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost]
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _authService.RegisterUser(dto);
            return Ok();
        }
    }
}
