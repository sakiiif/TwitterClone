using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TwitterClone.Application.Dtos.Message
{
    public class UpdateMessageDto
    {
        [Required]
        [StringLength(1000)]
        public required string Content { get; set; }
    }
}
