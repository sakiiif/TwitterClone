using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();
        public User AddUser(User user)
        {
            _users.Add(user);
            return user;
        }

        public bool DeleteUser(User user)
        {
            return _users.Remove(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(x => string.Equals(x.Email, email.Trim(), StringComparison.OrdinalIgnoreCase) );
        }

        public User? GetUserById(Guid id)
        {
            return _users.SingleOrDefault(x => x.Id == id);
        }

        public List<User> GetUsers()
        {
            return _users.ToList();
        }

        public User UpdateUser(User user) // replace fully
        {
            _users.RemoveAll(x => x.Id == user.Id);
            _users.Add(user);
            return user;
        }
    }
}
