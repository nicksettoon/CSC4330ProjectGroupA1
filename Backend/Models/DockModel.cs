using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class DockModel
    {
        public int DockNumber { get; set; }

        public List<Rental> Rentals { get; set; }

        public double TotalRevenue { get; set; }
    }
}
