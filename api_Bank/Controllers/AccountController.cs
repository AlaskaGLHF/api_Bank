using api_Bank.Dtos;
using api_Bank.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api_Bank.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        public AccountController(ITokenService tokenServices,
       IUserService userService)
        {
            _tokenService = tokenServices;
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto regiserDto)
        {
            try
            {
                var createdUser = await _userService.CreateRegUserAsync(RegisterDto);
                return Ok(
                new NewUserDto
                {
                    Name = createdUser.Name,
                    Email = createdUser.Email,
                    Token = _tokenService.CreateToken(createdUser)
                }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto LoginDto)
        {
            var user = await
           _userService.GetByIdAsyncUser(LoginDto.Name.ToLower());
            if (user == null)
            {
                return Unauthorized("Invalid username!");
            }
            if (!LoginDto.Password.Equals(user.Password))
            {
                return Unauthorized("Username not found and/or password");
            }
            return Ok(
            new NewUserDto
            {
                Name = user.Name,
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            }
            );
        }
    }
}
