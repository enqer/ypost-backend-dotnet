using Microsoft.AspNetCore.Mvc;
using ypost_backend_dotnet.Services;

namespace ypost_backend_dotnet.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }
    }
}
