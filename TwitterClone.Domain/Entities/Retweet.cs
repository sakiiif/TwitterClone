using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Retweet : BaseEntity
    {
        private Guid _tweetId;
        private Guid _userId;
        private string _comment; // for sharing with a caption

        public Retweet( Guid tweetId, Guid userId) : base() // constructor
        { 
            _tweetId = tweetId;
            _userId = userId;
        }

        // properties
        public Guid TweetId { get { return _tweetId; } }
        public Guid UserId { get { return _userId; } }
        public string Comment { get { return _comment; } set { _comment = value; } }
    }
}
