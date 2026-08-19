using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public sealed class SystemNotification : Notification
    {
        private string _criticalLevel; // how much critical
        public SystemNotification(Guid userId) : base(userId, "System") // constructor
        {

        }

        public string CriticalLevel { get { return _criticalLevel; } set { _criticalLevel = value; } }
        public void AddMessage(string message)
        {
            Message = message;
        }

        public override string GetMessage()
        {
            return $"Some System Related thing happened!";

        }
    }
}
