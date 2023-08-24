using ReservationSystem.Domain.DTOs;
using ReservationSystem.Domain.Entities;
using ReservationSystem.Infrastructure.Repositories;

namespace ReservationSystem.Application.Services.ReservationService
{
    /// <summary>
    /// Reservation service
    /// </summary>
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IClubTableRepository _clubTableRepository;
        private readonly IUserRepository _userRepository;

        public ReservationService(IReservationRepository reservationRepository, IClubTableRepository clubTableRepository, IUserRepository userRepository)
        {
            _reservationRepository = reservationRepository;
            _clubTableRepository = clubTableRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Creates a reservation
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public bool CreateReservation(Reservation reservation)
        {
            reservation.ExpirationDate = reservation.ReservationDate.AddHours(1);

            // Verify club table exists
            var clubTableExists = _clubTableRepository.GetById(reservation.ClubTableId);

            // Verify user exists
            var userExists = _userRepository.GetById(reservation.UserId);

            // Verify if reservation date is valid
            var isValidReservationDate = reservation.ReservationDate > DateTime.Now;

            if (clubTableExists is not null && userExists is not null && isValidReservationDate)
            {
                return _reservationRepository.Create(reservation);
            }

            return false;
        }

        /// <summary>
        /// Deletes a reservation
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteReservation(int Id)
        {
            var reservation = _reservationRepository.GetById(Id);
            var clubTable = _clubTableRepository.GetById(reservation.ClubTableId);

            if (_reservationRepository.DeleteById(Id))
            {
                clubTable.TotalAvailable += 1;
                if(_clubTableRepository.Update(clubTable))
                {
                    return true;
                } else
                {
                    return false;
                }
            } else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a reservation by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ReservationDto GetReservationDto(int Id)
        {
            try
            {
                var reservation = _reservationRepository.GetById(Id);
                var user = _userRepository.GetById(reservation.UserId);
                var clubTable = _clubTableRepository.GetById(reservation.ClubTableId);

                return new ReservationDto()
                {
                    Id = reservation.Id,
                    AdminName = user.CompleteName,
                    UserId = user.Id,
                    AdminPhoneNumber = user.PhoneNumber,
                    ClubTableName = clubTable.CategoryName,
                    ClubTableId = clubTable.Id,
                    TotalGuests = reservation.TotalGuests,
                    ReservationDate = reservation.ReservationDate,
                    ExpirationDate = reservation.ExpirationDate
                };
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets all the reservations
        /// </summary>
        /// <returns></returns>
        public List<ReservationDto> GetReservationsDto()
        {
            var reservationsDto = new List<ReservationDto>();

            try
            {
                var reservations = _reservationRepository.GetAll();

                foreach (var reservation in reservations)
                {
                    var user = _userRepository.GetById(reservation.UserId);
                    var clubTable = _clubTableRepository.GetById(reservation.ClubTableId);
                    var reservationDto = new ReservationDto()
                    {
                        Id = reservation.Id,
                        AdminName = user.CompleteName,
                        UserId = user.Id,
                        AdminPhoneNumber = user.PhoneNumber,
                        ClubTableName = clubTable.CategoryName,
                        ClubTableId = clubTable.Id,
                        TotalGuests = reservation.TotalGuests,
                        ReservationDate = reservation.ReservationDate,
                        ExpirationDate = reservation.ExpirationDate
                    };

                    reservationsDto.Add(reservationDto);
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }

            reservationsDto = reservationsDto.Where(reservation => reservation.ReservationDate >= DateTime.Now).ToList();

            return reservationsDto;
        }

        /// <summary>
        /// Updates a reservation
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public bool UpdateReservation(Reservation reservation)
        {
            return _reservationRepository.Update(reservation);
        }
    }
}
