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
            return _userRepository.GetById(Id);
        }

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            return _userRepository.GetAll();
        }

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UpdateUser(User user)
        {
           return _userRepository.UpdateById(user);
        }
    }
}
