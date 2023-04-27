using ReservationSystem.Domain.Entities;
using ReservationSystem.Infrastructure.Repositories;

namespace ReservationSystem.Application.Services
{
    /// <summary>
    /// This is the club table service.
    /// Here you can implement business logic.
    /// </summary>
    public class ClubTableService : IClubTableService
    {
        private readonly IClubTableRepository _clubTableRepository;

        public ClubTableService(IClubTableRepository clubTableRepository)
        {
            _clubTableRepository = clubTableRepository;
        }

        /// <summary>
        /// Creates a club table
        /// </summary>
        /// <param name="clubTable"></param>
        /// <returns></returns>
        public bool CreateClubTable(ClubTable clubTable)
        {
            return _clubTableRepository.Create(clubTable);
        }

        /// <summary>
        /// Deletes a club table by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteClubTable(int Id)
        {
            return _clubTableRepository.DeleteById(Id);
        }

        /// <summary>
        /// Gets a club table by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ClubTable GetClubTable(int Id)
        {
            return _clubTableRepository.GetById(Id);
        }

        /// <summary>
        /// Gets all club tables
        /// </summary>
        /// <returns></returns>
        public List<ClubTable> GetClubTables()
        {
            return _clubTableRepository.GetAll();
        }

        /// <summary>
        /// Updates a club table
        /// </summary>
        /// <param name="clubTable"></param>
        /// <returns></returns>
        public bool UpdateClubTable(ClubTable clubTable)
        {
            return _clubTableRepository.UpdateById(clubTable);
        }
    }
}
