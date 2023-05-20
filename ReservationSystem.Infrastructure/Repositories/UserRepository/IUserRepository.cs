using ReservationSystem.Domain.Entities;

namespace ReservationSystem.Infrastructure.Repositories
{
    /// <summary>
    /// User repository interface
    /// </summary>
    public interface IUserRepository
    {
        public bool Create(User user);

        public List<User> GetAll();

        public User GetById(int id);

        public bool DeleteById(int id);

        public bool Update(User user);
    }
}
