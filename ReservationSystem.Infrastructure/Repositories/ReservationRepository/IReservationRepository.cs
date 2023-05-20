using ReservationSystem.Domain.Entities;

namespace ReservationSystem.Infrastructure.Repositories
{
    /// <summary>
    /// Reservation repository interface
    /// </summary>
    public interface IReservationRepository
    {
        public bool Create(Reservation reservation);

        public List<Reservation> GetAll();

        public Reservation GetById(int id);

        public bool DeleteById(int id);

        public bool Update(Reservation reservation);
    }
}
