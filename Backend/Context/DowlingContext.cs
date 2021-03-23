using Backend.Entities;
using Microsoft.EntityFrameworkCore;

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
