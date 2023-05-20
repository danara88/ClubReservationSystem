using ReservationSystem.Domain.DTOs;
using ReservationSystem.Domain.Entities;

namespace ReservationSystem.Application.Services
{
    /// <summary>
    /// Reservation service interface
    /// </summary>
    public interface IReservationService
    {
        public bool CreateReservation(Reservation reservation);

        public List<ReservationDto> GetReservationsDto();

        public ReservationDto GetReservationDto(int Id);

        public bool DeleteReservation(int Id);

        public bool UpdateReservation(Reservation reservation);
    }
}
