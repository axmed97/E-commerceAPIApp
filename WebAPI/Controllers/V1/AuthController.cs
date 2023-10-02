using Business.Abstract;
using Entities.DTOs.UserDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [MapToApiVersion("1.0")]
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterDTO userRegisterDTO)
        {
            var result = _userService.Register(userRegisterDTO);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [MapToApiVersion("1.0")]
        [HttpPost("login")]
        [ProducesResponseType(typeof(IEnumerable<UserLoginDTO>), StatusCodes.Status201Created)]
        public IActionResult Login([FromBody] UserLoginDTO userLoginDTO)
        {
            var result = _userService.Login(userLoginDTO);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [MapToApiVersion("1.0")]
        [HttpGet("verifypassword")]
        public IActionResult VerifyPassword([FromQuery] string email, [FromQuery] string token)
        {
            var result = _userService.VerifyEmail(email, token);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
