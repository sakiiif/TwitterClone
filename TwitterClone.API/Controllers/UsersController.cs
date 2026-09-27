using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    // api/Users
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UsersController(IConfiguration configuration )
        {
            _configuration = configuration;
        }

        // GET /api/Users
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = new List<User>
            {
                new User(),
                new User(),
                new User()
            };

            return Ok(users);
        }

        // GET /api/Users/{id}
        [HttpGet("{id}")]
        public IActionResult GetUserById([FromRoute] Guid id)
        {
            return Ok
            (
                new
                {
                    UserId = id,
                    FirstName = "first name",
                    LastName = "last lame",
                    Email = "email"
                }

            );
        }

        // POST /api/Users
        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser()
        {
            return Ok
            (
                new
                {
                    UserId = Guid.NewGuid(),
                    FirstName = "first",
                    LastName = "lastst",
                    Email = "email"
                }
            );
        }

        // PATCH /api/Users/{id}/email
        [HttpPatch("{id}/email")]
        public IActionResult UpdateUserEmail([FromRoute] Guid id, [FromBody] string email)
        {
            return Ok
             (
                 new
                 {
                     UserId = id,
                     Email = email
                 }
             );

        }

        // PUT /api/Users/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromRoute] Guid id)
        {
            return Ok
             (
                 new
                 {
                     UserId = id,
                     Email = "mew email",
                     Name = "updated name",
                     MoifiefAt = DateTime.UtcNow
                 }
             );

        }

        // DELETE /api/Users/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            return Ok
            (
                new
                {
                    UserId = id,
                    Message = "USeser deleted successfully!"
                }

            );
        }
    }
}
