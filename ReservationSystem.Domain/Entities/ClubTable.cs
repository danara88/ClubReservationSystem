using System.ComponentModel.DataAnnotations;

namespace ReservationSystem.Domain.Entities
{
    /// <summary>
    /// ClubTable entity
    /// </summary>
    public class ClubTable
    {
        /// <summary>
        /// ClubTable ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ClubTable Name
        /// </summary>
        [Required]
        public string CategoryName { get; set; }

        /// <summary>
        /// ClubTable minimum consumption
        /// </summary>
        [Required]
        public decimal MinConsumption { get; set; }

        /// <summary>
        /// ClubTable capacity
        /// </summary>
        [Required]
        public int Capacity { get; set; }

        /// <summary>
        /// Total clubTables available
        /// </summary>
        [Required]
        public int TotalAvailable { get; set; }

        /// <summary>
        /// ClubTable creation date and time
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// ClubTable updated date and time
        /// </summary>
        public DateTime UpdatedOn { get; set; }
    }
}
