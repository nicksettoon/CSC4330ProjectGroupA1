using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class AdminModel
    {
        public IList<Rental> Rentals { get; set; }

        public string CurrentUserEmail { get; set; }
    }
}
