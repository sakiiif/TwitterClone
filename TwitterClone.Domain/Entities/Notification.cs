using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Notification : BaseEntity
    {
        private Guid _userId;
        private string _type;
        private string _message;
        private bool _isRead;

        public Notification (Guid userId, string type, string message) : base() // constructor
        {
            _userId = userId;
            _type = type;
            _message = message;
            _isRead = false;
        }

        // properties

        public Guid UserId { get { return _userId; } }
        public string Type { get { return _type; } }
        public string Message { get { return _message; } }
        public bool IsRead { get { return _isRead; } set { _isRead = value; } }
    }
}
