using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Application.Dtos.Like
{
    public class LikeDto
    {
        public required Guid Id { get; set; }
        public required Guid UserId { get; set; }
        public required Guid TweetId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
