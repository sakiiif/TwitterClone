using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public abstract class Notification : BaseEntity
    {
        private Guid _userId;
        private string _type;
        private string _message;
        private bool _isRead;

        public Notification (Guid userId, string type) : base() // constructor
        {
            _userId = userId;
            _type = type;
            _isRead = false;
        }

        // properties

        public Guid UserId { get { return _userId; } }
        public string Type { get { return _type; } }
        protected string Message { get { return _message; } set { _message = value; } }
        public bool IsRead { get { return _isRead; } set { _isRead = value; } }

        // methods

        public abstract string GetMessage();
    }
}
