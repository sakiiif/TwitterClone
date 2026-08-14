using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Message
    {
        private Guid _id;
        private Guid _senderId;
        private Guid _receiverId;
        private string _content;
        private bool _isRead;
        private DateTime _sentAt;
        private DateTime _modifiedAt; // not sure why this
        private Guid _createdBy; // done by admins probably
        private Guid _modifiedBy; // done by admins probably

        public Message(Guid senderId, Guid receiverId, string msg) // constructor
        {
            _id = Guid.NewGuid();
            _sentAt = DateTime.UtcNow;
            _isRead = false;
            _senderId = senderId;
            _receiverId = receiverId;
            _content = msg;
        }

        // properties

        public Guid Id { get { return _id; } }
        public Guid SenderId { get { return _senderId; } }
        public Guid ReceiverId { get { return _receiverId; } }
        public string Content { get { return _content; } set { _content = value; } }
        public bool IsRead { get { return _isRead; } set { _isRead = value; } }
        public DateTime SentAt { get { return _sentAt; } }
        public DateTime ModifiedAt { get { return _modifiedAt; } set { _modifiedAt = value; } }

    }
}
