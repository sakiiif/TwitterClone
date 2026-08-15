using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Bookmark : BaseEntity
    {
        private Guid _tweetId;
        private Guid _userId;

        public Bookmark (Guid userId, Guid tweetId) : base() // constructor
        {
            _userId = userId;
            _tweetId = tweetId;
        }

        // properties

        public Guid TweetId { get { return _tweetId; } }
        public Guid UserId { get { return _userId; } }
    }
}
