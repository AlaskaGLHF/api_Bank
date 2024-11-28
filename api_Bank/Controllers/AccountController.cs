using api_Bank.Dtos;
using api_Bank.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api_Bank.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                var newUserDto = await _userService.RegisterUserAsync(registerDto);

                return Ok(newUserDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred during registration.");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
           
            var newUserDto = await _userService.AuthenticateAsync(loginDto);

            if (newUserDto == null)
            {
                return Unauthorized("Invalid username or password!"); 
            }

            return Ok(newUserDto); 
        }
    }
}
