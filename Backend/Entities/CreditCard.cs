using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class CreditCard
    {
        [Required]
        public string CardHolderName { get; set; }
        
        [Key]
        public string CCNumber { get; set; }

        [Required]
        public DateTime ExpDate { get; set; }

        [Required]
        public int SecurityNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public bool Valid { get; set; }
    }
}
