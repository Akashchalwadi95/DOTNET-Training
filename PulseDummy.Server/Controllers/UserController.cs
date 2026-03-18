using Microsoft.AspNetCore.Mvc;
using PulseDummy.Server.Interfaces;
using PulseDummy.Server.WebModels;

namespace PulseDummy.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("getUserData")]
        public async Task<IActionResult> GetUserData()
        {
            var (success, message, data) = await _userServices.GetUserDataAsync();
            if (!success)
                return BadRequest(new { message });
            return Ok(new { message, data });
        }
    }
}
