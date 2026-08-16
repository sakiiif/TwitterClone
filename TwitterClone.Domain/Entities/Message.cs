using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Message : BaseEntity
    {
        private Guid _senderId;
        private Guid _receiverId;
        private string _content;
        private bool _isRead;
        private DateTime _sentAt; // is it actually required? cause already "CreatedAt" available in BaseEntity

        public Message(Guid senderId, Guid receiverId, string msg) : base() // constructor
        {
            _sentAt = DateTime.UtcNow;
            _isRead = false;
            _senderId = senderId;
            _receiverId = receiverId;
            _content = msg;
        }

        // properties

        public Guid SenderId { get { return _senderId; } }
        public Guid ReceiverId { get { return _receiverId; } }
        public string Content { get { return _content; } set { _content = value; } }
        public bool IsRead { get { return _isRead; } set { _isRead = value; } }
        public DateTime SentAt { get { return _sentAt; } }

    }
}
