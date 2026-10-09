using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TwitterClone.Application.Dtos.User;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    // api/Users
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        public UsersController(IConfiguration configuration, IUserService userService )
        {
            _configuration = configuration;
            _userService = userService;// DI injection
        }

        // GET /api/Users
        [HttpGet]
        [ProducesResponseType(typeof(List<UserDto>), StatusCodes.Status200OK)]
        public IActionResult GetUsers()
        {
            return Ok( _userService.GetUsers() );
        }

        // GET /api/Users/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUserById([FromRoute] Guid id)
        {
            var user = _userService.GetUserById(id);
            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST /api/Users
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult CreateUser([FromBody] CreateUserDto createUserDto )
        {
            var createdUser = _userService.CreateUser(createUserDto);
            if( createdUser == null)
            {
                // Input is already validated by [ApiController], so the only failure left is a taken email.
                return Conflict($"A user with email '{createUserDto.Email}' already exists.");
            }

            //return Ok(createdUser);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        // PATCH /api/Users/{id}/phoneNumber
        [HttpPatch("{id}/phoneNumber")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateUserPhoneNumber([FromRoute] Guid id, [FromBody, Required, Phone] string phoneNumber)
        {
            var user = _userService.UpdateUserPhoneNumber(id, phoneNumber);
            if( user == null )
            {
                return NotFound();
            }
            
            return Ok(user);

        }

        // PUT /api/Users/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserDto updateUserDto)
        {
            var user = _userService.UpdateUser(id, updateUserDto);
            if(user == null)
            {
                return NotFound();
            }
            
            return Ok(user);
        }

        // DELETE /api/Users/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            var isDeleted = _userService.DeleteUser(id);
            if(isDeleted == false)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}
