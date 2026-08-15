using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Comment
    {
        private Guid _id;
        private Guid _userId;
        private Guid _tweetId;
        private DateTime _createdAt;
        private DateTime _modifiedAt; // not sure why this
        private Guid _createdBy; // done by admins probably
        private Guid _modifiedBy; // done by admins probably

        public Comment(Guid userId, Guid tweetId) // constructor
        {
            _id = Guid.NewGuid();
            _createdAt = DateTime.UtcNow;
            _userId = userId;
            _tweetId = tweetId;
        }

        // properties
        public Guid Id { get { return _id; } }
        public Guid TweetId { get { return _tweetId; } }
        public Guid UserId { get { return _userId; } }
        public DateTime CreatedAt { get { return _createdAt; } }
        public DateTime ModifiedAt { get { return _modifiedAt; } set { _modifiedAt = value; } }

    }
}
