using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Comment : BaseEntity
    {
        private Guid _userId;
        private Guid _tweetId;
        private string _content;

        public Comment(Guid userId, Guid tweetId, string msg) : base() // constructor
        {
            _userId = userId;
            _tweetId = tweetId;
            _content = msg;
        }

        // properties
        public Guid TweetId { get { return _tweetId; } }
        public Guid UserId { get { return _userId; } }
        public string Content { get { return _content; } set { _content = value; } }

    }
}
