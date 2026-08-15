using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Retweet
    {
        private Guid _id;
        private Guid _tweetId;
        private Guid _userId;
        private string _comment; // for sharing with a caption
        private DateTime _createdAt;
        private DateTime _modifiedAt; // not sure why this
        private Guid _createdBy; // done by admins probably
        private Guid _modifiedBy; // done by admins probably

        public Retweet( Guid tweetId, Guid userId) // constructor
        { 
            _id = Guid.NewGuid();
            _createdAt = DateTime.UtcNow;
            _tweetId = tweetId;
            _userId = userId;
        }

        // properties
        public Guid Id { get { return _id; } }
        public Guid TweetId { get { return _tweetId; } }
        public Guid UserId { get { return _userId; } }
        public string Comment { get { return _comment; } set { _comment = value; } }
        public DateTime CreatedAt { get { return _createdAt; } }
    }
}
