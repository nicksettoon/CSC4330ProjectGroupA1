using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class Bike
    {
        [Key]
        public int BikeNumber { get; set; }

        [Required]
        public bool Rented { get; set; }
    }
}
