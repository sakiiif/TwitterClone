using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Application.Dtos.Tweet
{
    public class UpdateTweetDto
    {
        [Required]
        public required string Content { get; set; }
    }
}
