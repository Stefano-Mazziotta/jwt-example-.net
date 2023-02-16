using jwt_example.Interfaces;
using jwt_example.Models;
using jwt_example.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace jwt_example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILoginService _loginService;

        public LoginController(IConfiguration config, ILoginService loginService)
        {
            _configuration = config;
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var currentUser = _loginService.GetCurrentUser(identity);
            if (currentUser == null)
            {
                return NotFound("Current user not found");
            }
            return Ok($"Hi { currentUser.firstname }, your role is {currentUser.role}");
        }

        [HttpPost]
        public IActionResult Login(LoginUserModel loginUser)
        {
            var user = _loginService.Authenticate(loginUser);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var token = _loginService.GenerateToken(user);
            return Ok(token);
        }
    }
}
