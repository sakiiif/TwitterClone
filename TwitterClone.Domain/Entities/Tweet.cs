using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Tweet
    {
        private Guid _id;
        private Guid _userId;
        private string _Content;
        private DateTime _createdAt;
        private DateTime _modifiedAt;
        private Guid _createdBy; // done by admins probably
        private Guid _modifiedBy; // done by admins probably

        public Tweet(string content, Guid userId) // constructor
        { 
            _id = Guid.NewGuid();
            _Content = content;
            _userId = userId;
            _createdAt = DateTime.UtcNow;
        }

        // properties

        public Guid Id { get { return _id; } }
        public Guid UserId { get { return _userId; } }
        public string Content { 
            get { return _Content; }
            set { 
                _Content = value;
                _modifiedAt = DateTime.UtcNow;
            }
        }
        public DateTime CreatedAt { get { return _createdAt; } }
        public DateTime ModifiedAt { get { return _modifiedAt; } }
    }
}
