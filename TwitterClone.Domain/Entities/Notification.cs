using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Notification
    {
        private Guid _id;
        private Guid _userId;
        private string _type;
        private string _message;
        private bool _isRead;
        private DateTime _createdAt;
        private DateTime _modifiedAt; // not sure why this
        private Guid _createdBy; // done by admins probably
        private Guid _modifiedBy; // done by admins probably

        public Notification (Guid userId, string type, string message) // constructor
        {
            _id = Guid.NewGuid();
            _createdAt = DateTime.UtcNow;
            _userId = userId;
            _type = type;
            _message = message;
            _isRead = false;
        }

        // properties

        public Guid Id { get { return _id; } }
        public Guid UserId { get { return _userId; } }
        public string Type { get { return _type; } }
        public string Message { get { return _message; } }
        public DateTime CreatedAt { get { return _createdAt; } }
        public bool IsRead { get { return _isRead; } set { _isRead = value; } }
    }
}
