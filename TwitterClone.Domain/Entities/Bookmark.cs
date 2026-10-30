using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Bookmark : BaseEntity
    {
        private Guid _tweetId;
        private Guid _userId;

        public Bookmark () : base() // constructor
        {

        }

        // properties

        public Guid TweetId { get { return _tweetId; } set { _tweetId = value; } }
        public Guid UserId { get { return _userId; } set { _userId = value; } }
    }
}
