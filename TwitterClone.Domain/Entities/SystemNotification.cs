using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public sealed class SystemNotification : Notification
    {
        public SystemNotification(Guid userId, string type, string message) : base(userId, "System", message) // constructor
        {

        }
    }
}
