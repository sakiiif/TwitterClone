using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos.User;

namespace TwitterClone.Application.Interfaces
{
    public interface IPasswordHasher
    {
        bool VerifyPassword(UserDto user, string password, string passwordHash);
        string Hash(UserDto user, string password);
    }
}
