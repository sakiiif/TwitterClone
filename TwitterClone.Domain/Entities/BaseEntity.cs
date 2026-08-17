using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; }
        public DateTime CreatedAt { get; } // without set means it cannot even set within the class itself after initialization
        public DateTime? ModifiedAt { get;  private set; } // ? means Nullable data/property
        public Guid CreatedBy { get; private set; } // done by admins probably
        public Guid? ModifiedBy { get; private set; } // private set gives much readability & improve abstraction too maybe

        public BaseEntity () // constructor
        {
            Id = Guid.NewGuid ();
            CreatedAt = DateTime.UtcNow;
        }

        
    }
}
