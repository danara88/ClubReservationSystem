﻿using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ReservationSystem.Domain.Entities
{
    /// <summary>
    /// User entity
    /// </summary>
    public class User
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User complete name
        /// </summary>
        [Required]
        public string CompleteName { get; set; }

        /// <summary>
        /// User phone number
        /// </summary>
        [Required]
        public string PhoneNumber { get; set; }

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
