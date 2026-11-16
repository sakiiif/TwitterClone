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

        protected Notification (string type) : base() // constructor
        {
            _type = type;
            _isRead = false;
        }

        protected Notification() : base() // for EF Core
        {

        }

        // properties

        public Guid UserId { get { return _userId; } set { _userId = value; } }
        public string Type { get { return _type; } }
        protected string Message { get { return _message; } set { _message = value; } }
        public bool IsRead { get { return _isRead; } set { _isRead = value; } }

        // methods

        public abstract string GetMessage();
    }
}
