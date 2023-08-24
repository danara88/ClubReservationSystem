using ReservationSystem.Domain.Entities;
using ReservationSystem.Infrastructure.Repositories;

namespace ReservationSystem.Application.Services
{
    /// <summary>
    /// User service
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Creates a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool CreateUser(User user)
        {
            return _userRepository.Create(user);
        }

        /// <summary>
        /// Get users by complete name
        /// </summary>
        /// <param name="completeName"></param>
        /// <returns></returns>
        public List<User> GetUsersByCompleteName(string completeName)
        {
            var users = _userRepository.GetAll()
                                       .Where(u => u.CompleteName.IndexOf(completeName, StringComparison.OrdinalIgnoreCase) >= 0)
                                       .ToList();
            return users;
        }

        /// <summary>
        /// Deletes a user by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteUser(int Id)
        {
           return _userRepository.DeleteById(Id);
        }

        /// <summary>
        /// Gets a user by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public User GetUser(int Id)
        {
            try
            {
                return _userRepository.GetById(Id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            try
            {
                return _userRepository.GetAll();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UpdateUser(User user)
        {
           return _userRepository.Update(user);
        }
    }
}
