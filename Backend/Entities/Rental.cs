using Backend.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
