using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class CreditCard
    {
        public string CardHolderName { get; set; }
        
        [Key]
        public string CCNumber { get; set; }

        public DateTime ExpDate { get; set; }

        public int SecurityNumber { get; set; }

        public string Address { get; set; }
    }
}
