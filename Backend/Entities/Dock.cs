using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class Dock
    {
        public int Id { get; set; }

        public ICollection<Bike> Bikes { get; set; }
    }
}
