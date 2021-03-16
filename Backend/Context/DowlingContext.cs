using Backend.Areas.Identity.Data;
using Backend.Entities;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Context
{
    public class DowlingContext : DbContext
    {
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=C:\dowling_db\Downling.db");
    }
}
