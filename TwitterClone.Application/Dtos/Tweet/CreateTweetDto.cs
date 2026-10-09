using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Application.Dtos.Tweet
{
    public class CreateTweetDto
    {
        [Required]
        public required Guid UserId { get; set; }

        [Required]
        public required string Content { get; set; }
    }
}
