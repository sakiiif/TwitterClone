using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public sealed class SystemNotification : Notification
    {
        private string _criticalLevel; // how much critical
        public SystemNotification(Guid userId, string type, string message) : base(userId, "System", message) // constructor
        {

        }

        public string CriticalLevel { get { return _criticalLevel; } set { _criticalLevel = value; } }
        public void AddMessage(string message)
        {
            Message = message;
        }
    }
}
