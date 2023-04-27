using ReservationSystem.Domain.Entities;

namespace ReservationSystem.Application.Services
{
    /// <summary>
    /// Club table interface
    /// </summary>
    public interface IClubTableService
    {
        public bool CreateClubTable(ClubTable clubTable);

        public List<ClubTable> GetClubTables();

        public ClubTable GetClubTable(int Id);

        public bool DeleteClubTable(int Id);

        public bool UpdateClubTable(ClubTable clubTable);
    }
}
