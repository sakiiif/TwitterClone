using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Follow
    {
        private Guid _id;
        private Guid _userId;
        private Guid _followingId;
        private DateTime _createdAt;
        private DateTime _modifiedAt; // not sure why this
        private Guid _createdBy; // done by admins probably
        private Guid _modifiedBy; // done by admins probably

        public Follow (Guid userId, Guid followingId) // constructor
        {
            _id = Guid.NewGuid();
            _createdAt = DateTime.UtcNow;
            _userId = userId;
            _followingId = followingId;
        }

        // properties

        public Guid Id { get { return _id; } }
        public Guid UserId { get { return _userId; } }
        public Guid FollowingId { get { return _followingId; } }
        public DateTime CreatedAt { get { return _createdAt; } }
    }
}
