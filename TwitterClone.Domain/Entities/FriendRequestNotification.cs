using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public sealed class FriendRequestNotification : Notification
    {
        private Guid _requestedByUserId;
        private Guid _requestedToUserId;
        private bool _isAccepted; // accept or reject
        public FriendRequestNotification(Guid userId, string type, string message) : base(userId, "FriendRequest", message) // constructor
        {

        }

        public Guid RequestedByUserId { get { return _requestedByUserId; } set { _requestedByUserId = value; } }
        public Guid RequestedToUserId { get { return _requestedToUserId; } set { _requestedToUserId = value; } }
        public bool IsAccepted { get { return _isAccepted; } set { _isAccepted = value; } }
        public void AddMessage(string message)
        {
            Message = message;
        }

    }
}
