using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class User
    {
        private Guid _id;
        private string _firstName;
        private string _lasttName;
        private string _email;
        private DateTime _createdAt;
        private DateTime _modifiedAt;
        private Guid _createdBy; // done by admins probably
        private Guid _modifiedBy; // done by admins probably

        public User() // constructor
        {
            _id = Guid.NewGuid();
            _createdAt = DateTime.UtcNow;
        }

        // properties

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lasttName; }
            set { _lasttName = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public DateTime CreatedAt { get { return _createdAt; }  }
        public DateTime ModifiedAt { get { return _modifiedAt; } set { _modifiedAt = value; } }


    }
}
