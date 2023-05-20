using ReservationSystem.Domain.Entities;

namespace ReservationSystem.Infrastructure.Repositories
{
    /// <summary>
    /// ClubTable repository interface
    /// </summary>
    public interface IClubTableRepository
    {
        public bool Create(ClubTable clubTable);

        public List<ClubTable> GetAll();

        public ClubTable GetById(int id);

        public bool DeleteById(int id);

        public bool Update(ClubTable clubTable);
    }
}
