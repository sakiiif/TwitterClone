using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class User : BaseEntity, IFollowable, INotifiable
    {
        private string _firstName;
        private string _lasttName;
        private string _email;

        private List<Guid> _following;
        private List<Notification> _unreadNotifications;

        public User() : base() // constructor
        {
            _following = new List<Guid>();
            _unreadNotifications = new List<Notification>();
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

        // interface contracts

        public void Follow(Guid userId)
        {
            if( !_following.Contains(userId) )
            {
                _following.Add(userId);
            }
        }

        public void UnFollow(Guid userId)
        {
            if( _following.Contains(userId) )
            {
                _following.Remove(userId);
            }
        }

        public void AddNotification(Notification notification)
        {
            if( !_unreadNotifications.Contains(notification)  )
            {
                _unreadNotifications.Add(notification);
            }
        }

        public void ReadNotification(Notification notification)
        {
            if( _unreadNotifications.Contains(notification) )
            {
                _unreadNotifications.Remove(notification);
            }
        }
    }
}
