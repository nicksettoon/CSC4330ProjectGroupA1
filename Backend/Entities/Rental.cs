using Backend.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class Rental
    {
        [Key]
        public int BikeNumber { get; set; }

        [Required]
        public DateTime CheckOutTime { get; set; }

        [Required]
        public DateTime CheckInTime { get; set; }

        [Required]
        public string RenterEmail { get; set; }
    }
}
