using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Data
{
    public class UserRepository
    {
        private readonly List<User> _users = new List<User>(); // confusion for new

        public List<User> GetUsers()
        {
            return _users;
        }

        public User? GetUserById(Guid id)
        {
            return _users.SingleOrDefault(x => x.Id == id);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(x => x.Email == email);
        }

        public User AddUser(User user)
        {
            _users.Add(user);
            return user;
        }

        public void UpdateUser(User user) // fully replace
        {
            _users.RemoveAll(x => x.Id == user.Id);
            _users.Add(user);
            //return user;
        }

        public User UpdateUserEmail(Guid id, string email)
        {
            var user = _users.SingleOrDefault( x => x.Id == id );
            user.Email = email;
            return user;
        }

        public bool DeleteUser(User user)
        {
            return _users.Remove(user);

        }
    }
}
