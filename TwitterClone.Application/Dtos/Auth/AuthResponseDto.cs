using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos.User;

namespace TwitterClone.Application.Dtos.Auth
{
    public class AuthResponseDto
    {
        public required string AccessToken { get; set; }
        public required DateOnly ExpiryAt { get; set; }
        public required UserDto UserDto { get; set; }
    }
}
