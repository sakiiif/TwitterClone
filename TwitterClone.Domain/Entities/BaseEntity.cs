using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; }
        public DateTime? ModifiedAt { get;  set; } // ? means Nullable data/property
        public Guid CreatedBy { get; set; } // done by admins probably
        public Guid? ModifiedBy { get; set; } // done by admins probably

        public BaseEntity () // constructor
        {
            Id = Guid.NewGuid ();
            CreatedAt = DateTime.UtcNow;
        }

        
    }
}
