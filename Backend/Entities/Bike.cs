using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class Bike
    {
        public int Id { get; set; }

        [Required]
        public bool Rented { get; set; } 

        public int DockId { get; set; }
        public Dock Dock { get; set; }
    }
}
