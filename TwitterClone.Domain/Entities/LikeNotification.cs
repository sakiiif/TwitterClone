using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public sealed class LikeNotification : Notification
    {
        private Guid _tweetId;
        private Guid _likedByUserId;
        private Guid _likeId;

        public LikeNotification (Guid userId, Guid likedBy) : base(userId, "Like") // constructor
        {
            _likedByUserId = likedBy;
        }

        public Guid TweetId { get { return _tweetId; } set { _tweetId = value; } }
        public Guid LikedByUserId { get { return _likedByUserId; } set { _likedByUserId = value; } }
        public Guid LikeId { get { return _likeId; } }
        public void AddMessage(string message)
        {
            Message = message;
        }

        public override string GetMessage()
        {
            return $"User Id: {_likedByUserId} liked your Tweet Id: {_tweetId}";
        }

    }
}
