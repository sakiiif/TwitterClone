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
        public CommentNotification(Guid userId, Guid commenterId) : base(userId, "Comment") // constructor
        {
            _commentByUserId = commenterId;
        }

        // properties

        public Guid TweetId { get { return _tweetId; } set { _tweetId = value; } }
        public Guid CommentId { get { return _commentId; } set { _commentId = value; }  }
        public Guid CommentByUserId { get { return _commentByUserId; } set { _commentByUserId = value; } }
        public void AddMessage(string message)
        {
            Message = message;
        }

        // methods

        public override string GetMessage()
        {
            return $"User Id: {_commentByUserId} commented on your Tweet Id: {_tweetId}";
        }

    }
}
