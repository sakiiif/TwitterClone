using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Follow : BaseEntity
    {
        private Guid _userId;
        private Guid _followingId;

        public Follow (Guid userId, Guid followingId) : base() // constructor
        {
            _userId = userId;
            _followingId = followingId;
        }

        // properties

        public Guid UserId { get { return _userId; } }
        public Guid FollowingId { get { return _followingId; } }
    }
}
