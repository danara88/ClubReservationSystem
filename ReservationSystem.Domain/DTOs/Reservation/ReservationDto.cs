namespace ReservationSystem.Domain.DTOs
{
    /// <summary>
    /// Reservation DTO
    /// </summary>
    public class ReservationDto
    {
        public int Id { get; set; }

        public string AdminName { get; set; }

        public int UserId { get; set; }

        public string ClubTableName { get; set; }

        public int ClubTableId { get; set; }

        public int TotalGuests { get; set; }

        public string AdminPhoneNumber { get; set; }

        public DateTime ReservationDate { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
