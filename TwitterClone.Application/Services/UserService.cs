using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos.User;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Mappings;
using TwitterClone.Domain.Entities;


namespace TwitterClone.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITweetRepository _tweetRepository;

        public UserService(IUserRepository userRepository, ITweetRepository tweetRepository)
        {
            _userRepository = userRepository;
            _tweetRepository = tweetRepository;
        }
        // ---
        
        public UserDto? CreateUser(CreateUserDto createUserDto)
        {
            if (string.IsNullOrWhiteSpace(createUserDto.FirstName) || string.IsNullOrWhiteSpace(createUserDto.LastName) || string.IsNullOrWhiteSpace(createUserDto.Email))
            {
                return null; // required this checking? as [ApiController] already doing it
            }

            var existingUser = _userRepository.GetUserByEmail(createUserDto.Email); // database

            if (existingUser != null)
            {
                return null;
            }

            var createdUser = _userRepository.AddUser(
                    new User()
                    {
                        FirstName = createUserDto.FirstName,
                        LastName = createUserDto.LastName,
                        Email = createUserDto.Email,
                    }
                );

            return createdUser.ToDto();
        }

        public bool DeleteUser(Guid id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null) return false;

            //// A user's tweets can't outlive the user.
            _tweetRepository.DeleteTweetsByUserId(id);

            return _userRepository.DeleteUser(user);
        }

        public UserDto? GetUserById(Guid id)
        {
            var user = _userRepository.GetUserById(id);

            return user?.ToDto();
        }

        public List<UserDto> GetUsers()
        {
            var users = _userRepository.GetUsers()
                .OrderBy(x => x.CreatedAt) // oldest first
                .Select(u => u.ToDto())
                .ToList();

            return users;
        }

        public UserDto? UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            var user = _userRepository.GetUserById(id);
            if(user == null) return null;

            user.FirstName = updateUserDto.FirstName; // updating
            user.LastName = updateUserDto.LastName;
            user.ModifyAt();

            user = _userRepository.UpdateUser(user);
            return user.ToDto();
        }

        public UserDto? UpdateUserPhoneNumber(Guid id, string phoneNumber)
        {
            var user = _userRepository.GetUserById(id);
            if( user == null) return null;

            user.PhoneNumber = phoneNumber;
            user.ModifyAt();

            user = _userRepository.UpdateUser(user);
            return user.ToDto();
        }
    }
}
