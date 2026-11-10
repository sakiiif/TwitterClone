using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        //private readonly List<User> _users = new List<User>();
        private readonly TwitterCloneDbContext _context;
        public UserRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            // _users.Add(user);
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public bool DeleteUser(User user)
        {
            // return _users.Remove(user);
            var existingUser = _context.Users.SingleOrDefault(u => u.Id == user.Id);

            if (existingUser == null)
                return false;

            _context.Users.Remove(existingUser);
            _context.SaveChanges();

            return true;
        }

        public User? GetUserByEmail(string email)
        {
            //return _users.SingleOrDefault(x => string.Equals(x.Email, email.Trim(), StringComparison.OrdinalIgnoreCase) );
            var normalizedEmail = email.Trim().ToLower();

            return _context.Users.SingleOrDefault(
                x => x.Email.ToLower() == normalizedEmail
            );
        }

        public User? GetUserById(Guid id)
        {
            //return _users.SingleOrDefault(x => x.Id == id);
            return _context.Users.SingleOrDefault(u => u.Id == id);
        }

        public List<User> GetUsers()
        {
            //return _users.ToList();
            return _context.Users.ToList();
        }

        public User UpdateUser(User user) // replace fully
        {
            //_users.RemoveAll(x => x.Id == user.Id);
            //_users.Add(user)
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}
