using Microsoft.AspNetCore.Mvc;
using PulseDummy.Server.WebModels;
using PulseDummy.Server.Interfaces;

namespace PulseDummy.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthServices _authServices;
        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDetailDto model)
        {
           var (success, message) = await _authServices.RegisterAsync(model);
            if(!success)
                return StatusCode(400, message);

            return StatusCode(201, message);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var (success, message) = await _authServices.LoginAsync(model);
            if (!success)
                return StatusCode(400, message);
            return StatusCode(200, message);
        }
    }
}
