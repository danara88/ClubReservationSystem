using System.ComponentModel.DataAnnotations;

namespace ReservationSystem.Domain.Entities
{
    /// <summary>
    /// Reservation entity
    /// </summary>
    public class Reservation
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Club table ID
        /// </summary>
        [Required]
        public int ClubTableId { get; set; }

        /// <summary>
        /// Total guests
        /// </summary>
        [Required]
        public int TotalGuests { get; set; }

        /// <summary>
        /// Reservation date
        /// </summary>
        [Required]
        public DateTime ReservationDate { get; set; }

        /// <summary>
        /// Reservation expiration date
        /// </summary>
        [Required]
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// User creation date and time
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// User updated date and time
        /// </summary>
        public DateTime UpdatedOn { get; set; }

    }
}
