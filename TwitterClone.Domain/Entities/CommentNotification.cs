using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public sealed class CommentNotification : Notification
    {
        private Guid _tweetId;
        private Guid _commentId;
        private Guid _commentByUserId;
        public CommentNotification(Guid userId, string message) : base(userId, "Comment", message) // constructor
        {

        }

        public Guid TweetId { get { return _tweetId; } set { _tweetId = value; } }
        public Guid CommentId { get { return _commentId; } set { _commentId = value; }  }
        public Guid CommentByUserId { get { return _commentByUserId; } set { _commentByUserId = value; } }
        public void AddMessage(string message)
        {
            Message = message;
        }

    }
}
