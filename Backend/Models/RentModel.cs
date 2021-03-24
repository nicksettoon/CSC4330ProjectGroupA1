using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class RentModel
    {
        [Required]
        [Display(Name = "Bike Number")]
        public int BikeNumber { get; set; }

        [Display(Name = "Check Out Time")]
        public DateTime CheckOut { get; set; }
 
        [Display(Name = "Check In Time")]
        public DateTime CheckIn { get; set; }

    }
}
