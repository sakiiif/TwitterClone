using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Comment : BaseEntity, ILikeable
    {
        private Guid _userId;
        private Guid _tweetId;
        private string _content;

        private static int _maxContentLength = 100;

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

        // interface contracts
        public bool CanBeLiked()
        {
            if( string.IsNullOrWhiteSpace(Content) ) return false;
            else return true;
        }
    }
}
