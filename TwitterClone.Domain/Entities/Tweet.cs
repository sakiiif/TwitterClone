using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Tweet : BaseEntity
    {
        private Guid _userId;
        private string _Content;

        public Tweet(string content, Guid userId) : base() // constructor
        { 
            _Content = content;
            _userId = userId;
        }

        // properties

        public Guid UserId { get { return _userId; } }
        public string Content { 
            get { return _Content; }
            set { 
                _Content = value;
                ModifiedAt = DateTime.UtcNow;
            }
        }
    }
}
