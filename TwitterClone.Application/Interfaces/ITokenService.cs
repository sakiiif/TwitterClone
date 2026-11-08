using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos.User;

namespace TwitterClone.Application.Interfaces
{
    public interface ITokenService
    {
        (string, DateOnly) GetToken(UserDto user);
    }
}
