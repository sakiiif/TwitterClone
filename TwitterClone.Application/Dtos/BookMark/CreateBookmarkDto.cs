using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Application.Dtos.BookMark
{
    public class CreateBookmarkDto
    {
        public required Guid UserId { get; set; }
        public required Guid TweetId { get; set; }
    }
}
