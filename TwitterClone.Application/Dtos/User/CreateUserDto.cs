using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Application.Dtos.User
{
    public class CreateUserDto
    {
        [Required]
        [StringLength(50)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public required string LastName { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }
}
