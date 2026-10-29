using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Application.Dtos.Notification
{
    public class NotificationDto
    {
        public required Guid Id { get; set; }
        public required Guid UserId { get; set; }
        public required string Type { get; set; }
        public required string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
