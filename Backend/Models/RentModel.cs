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

        [Display(Name = "Is the Bike Damaged")]
        public bool BikeDamaged { get; set; }

        public bool AlreadyCheckedOut { get; set; }

        public double Price { get; set; }

        public bool RentSuccessful { get; set; }

        public bool ReturnSuccessful { get; set; }

    }
}
