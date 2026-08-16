using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class User : BaseEntity
    {
        private string _firstName;
        private string _lasttName;
        private string _email;

        public User() : base() // constructor
        {

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

    }
}
