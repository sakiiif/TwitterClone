using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public sealed class MentionNotification : Notification
    {
        private Guid _mentionedByUserId;
        private Guid _mentionedToUserId;
        private Guid _tweetId;

        public MentionNotification(Guid userId, Guid mentionedByUserId) : base(userId, "Mention")
        {
            _mentionedByUserId = mentionedByUserId;
        }

        // properties

        public Guid MentionedByUserId { get { return _mentionedByUserId; } set { _mentionedByUserId = value; } }
        public Guid MentionedToUserId { get { return _mentionedToUserId; } set { _mentionedToUserId = value; }  }
        public Guid TweetId { get { return _tweetId; } set { _tweetId = value; } }

        // methtods

        public override string GetMessage()
        {
            return $"User Id: {_mentionedByUserId} mentioned you on Tweet Id: {_tweetId}";
        }
    }
}
