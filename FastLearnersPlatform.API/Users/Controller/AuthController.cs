using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FastLearnersPlatform.API.Users.Domain.Services;
using FastLearnersPlatform.API.Users.Domain.Resources;

namespace FastLearnersPlatform.API.Users.Controllers
{
    [Route("/api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginResource resource)
        {
            var response = await _userService.AuthenticateAsync(resource.Email, resource.Password);

            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.User);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterResource resource)
        {
            var response = await _userService.RegisterAsync(resource.Email, resource.Password, resource.FirstName, resource.LastName, resource.IdMembership);

            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.User);
        }
    }
}