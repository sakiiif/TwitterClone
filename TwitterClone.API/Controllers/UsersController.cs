using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.API.Data;
using TwitterClone.API.Dtos.User;
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
        private readonly UserRepository _userRepository;
        public UsersController(IConfiguration configuration, UserRepository userRepository )
        {
            _configuration = configuration;
            _userRepository = userRepository;// DI injection
        }

        // GET /api/Users
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();

            var userDtos = users.Select(x => new UserDto
                {   Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email
                }
            );

            return Ok(userDtos);
        }

        // GET /api/Users/{id}
        [HttpGet("{id}")]
        public IActionResult GetUserById([FromRoute] Guid id)
        {
            var user = _userRepository.GetUserById(id);

            if( user == null )
            {
                return NotFound();
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
            return Ok(userDto);
        }

        // POST /api/Users
        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser([FromBody] CreateUserDto userbody )
        {
            if( string.IsNullOrWhiteSpace(userbody.FirstName) || string.IsNullOrWhiteSpace(userbody.LastName) || string.IsNullOrWhiteSpace(userbody.Email) )
            {
                return BadRequest("FirstName, LastName and Email are required!");
            }
            if( _userRepository.GetUserByEmail(userbody.Email) != null  )
            {
                return Conflict("This Email already exists!");
            }

            var user = new User
            {
                FirstName = userbody.FirstName,
                LastName = userbody.LastName,
                Email = userbody.Email
            };

            _userRepository.AddUser(user);

            var userDto = new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return Ok(userDto);
        }

        // PATCH /api/Users/{id}/email
        [HttpPatch("{id}/email")]
        public IActionResult UpdateUserEmail([FromRoute] Guid id, [FromBody] string email)
        {
            if( string.IsNullOrWhiteSpace(email) )
            {
                return BadRequest("Email cant be empty!");
            }

            if( _userRepository.GetUserById(id) == null  )
            { 
                return NotFound();
            }

            var user = _userRepository.UpdateUserEmail(id, email);

            var userDto = new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
            return Ok(userDto);

        }

        // PUT /api/Users/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserDto userb)
        {
            if( string.IsNullOrWhiteSpace(userb.FirstName) || string.IsNullOrWhiteSpace(userb.LastName)  )
            {
                return BadRequest("first name or last name cant be empty!");
            }

            var user = _userRepository.GetUserById(id);
            if( user == null )
            {
                return NotFound();
            }

            user.FirstName = userb.FirstName;
            user.LastName = userb.LastName;
            _userRepository.UpdateUser(user);

            var userDto = new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
            return Ok(userDto);
        }

        // DELETE /api/Users/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            var user = _userRepository.GetUserById(id);
            if ( user  == null )
            {
                return NotFound();
            }

            var isDeleted = _userRepository.DeleteUser(user);
            if (isDeleted == true) return Ok(isDeleted);
            else return StatusCode(500, "Something went wrong1");

        }
    }
}
