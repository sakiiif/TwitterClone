using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User UpdateUser(User user);
        bool DeleteUser(User user);
        User? GetUserById(Guid id);
        User? GetUserByEmail(string email);
        List<User> GetUsers();
        
    }
}
