using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Tweet : BaseEntity, ILikeable
    {
        private Guid _userId;
        private string _Content;

        private static int _maxContentLength = 200; // class variable

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
                if( Content.Length <= _maxContentLength && !string.IsNullOrWhiteSpace(Content) )
                {
                    _Content = value;
                    ModifyAt(DateTime.UtcNow);
                }

            }
        }

        // interface contracts

        public bool CanBeLiked()
        {
            if( string.IsNullOrWhiteSpace(Content)  ) return false;
            else return true;
        }
    }
}
