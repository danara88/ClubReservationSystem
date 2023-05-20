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

        public List<User> GetUsersByCompleteName(string completeName);

        public User GetUser(int Id);

        public bool DeleteUser(int Id);

        public bool UpdateUser(User user);
    }
}
