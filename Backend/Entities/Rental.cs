using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities
{
    public class Rental
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Key { get; set; }

        [Required]
        public int BikeNumber { get; set; }

        [Required]
        public DateTime CheckOutTime { get; set; }

        [Required]
        public DateTime CheckInTime { get; set; }

        [Required]
        public string RenterEmail { get; set; }

        [Required]
        public bool IsBikeDamaged { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int RentDock { get; set; }

        [Required]
        public int ReturnDock { get; set; }
    }
}
