using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Follow : BaseEntity
    {
        private Guid _followerId;
        private Guid _followingId;

        public Follow ( ) : base() // constructor
        {
 
        }

        // properties

        public Guid FollowerId { get { return _followerId; } set { _followerId = value; } }
        public Guid FollowingId { get { return _followingId; } set { _followingId = value; } }
    }
}
