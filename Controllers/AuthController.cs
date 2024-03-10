using Microsoft.AspNetCore.Mvc;
using ypost_backend_dotnet.Models;
using ypost_backend_dotnet.Services;

namespace ypost_backend_dotnet.Controllers
{
    [ApiController]
    [Route("/api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("/register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
           
            _authService.RegisterUser(dto);
            return Ok();
        }

        [HttpPost("/login")]
        public ActionResult Login([FromBody] LoginDto dto)
        {
            string token = _authService.GenerateJwt(dto);
            return Ok(token);
        }
    }
}
