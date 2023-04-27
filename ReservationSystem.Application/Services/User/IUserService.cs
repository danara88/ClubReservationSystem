using ReservationSystem.Domain.Entities;

namespace ReservationSystem.Application.Services
{
    /// <summary>
    /// User service interface
    /// </summary>
    public interface IUserService
    {
        public bool CreateUser(User user);

        public List<User> GetUsers();

        public User GetUser(int Id);

        public bool DeleteUser(int Id);

        public bool UpdateUser(User user);
    }
}
