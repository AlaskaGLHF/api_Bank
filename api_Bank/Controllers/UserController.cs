using Microsoft.AspNetCore.Mvc;
using api_Bank.Services;
using System.Threading.Tasks;
using api_Bank.Dtos;
using api_Bank.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace api_Bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        // GET: api/cards
        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<IEnumerable<CardDto.CardDtoRead>>> GetAllCards()
        {
            var users = await _userService.GetAllAsyncUser();
            return Ok(users);
        }

        // GET api/user/{id}
        [Authorize(Roles = "User")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetByIdAsyncUser(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // POST api/user
        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<ActionResult<UserDto.UserDtoRead>> CreateUser([FromBody] UserDto.UserDtoCreate userDto)
        {
            if (userDto == null)
            {
                return BadRequest();
            }

            var createdUser = await _userService.CreateAsyncUser(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.UserId }, createdUser);
        }


        // PUT api/user/{id}
        [Authorize(Roles = "User")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto.UserDtoUpdate userDto)
        {
            if (id != userDto.UserId)
                return BadRequest("User ID mismatch.");

            await _userService.UpdateAsyncUser(id, userDto);
            return Ok(userDto);
        }

        // DELETE api/user/{id}
        [Authorize(Roles = "User")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.DeleteAsyncUser(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
    }
}
