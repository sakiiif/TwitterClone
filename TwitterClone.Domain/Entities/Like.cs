using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Like : BaseEntity
    {
        private Guid _userId;
        private Guid _tweetId;

        public Like ( Guid userId, Guid tweetId ) : base() // constructor
        {
            _userId = userId;
            _tweetId = tweetId;
        }

        // properties
        public Guid UserId { get { return _userId; } }
        public Guid TweetId { get { return _tweetId; } }
    }
}
