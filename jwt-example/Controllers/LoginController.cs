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
        private LoginService _loginService;

        public LoginController(IConfiguration config, LoginService loginService)
        {
            _configuration = config;
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult get()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var currentUser = _loginService.getCurrentUser(identity);
            if (currentUser == null)
            {
                return NotFound("Current user not found");
            }
            return Ok($"Hi { currentUser.firstname }, your role is {currentUser.role}");
        }

        [HttpPost]
        public IActionResult login(LoginUserModel loginUser)
        {
            var user = _loginService.authenticate(loginUser);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var token = _loginService.generateToken(user);
            return Ok(token);
        }
    }
}
