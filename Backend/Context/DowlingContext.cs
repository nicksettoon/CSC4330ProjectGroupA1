using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context
{
    public class DowlingContext : DbContext
    {
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Dock> Docks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=\dowling_db\Dowling.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Dock>()
                .HasMany(d => d.Bikes)
                .WithOne(b => b.Dock);*/

            modelBuilder.Entity<Bike>()
                .HasOne(b => b.Dock)
                .WithMany(d => d.Bikes)
                .HasForeignKey(b => b.DockId);

            var docks = new[]
            {
                new Dock
                {
                    Id = 1
                },

                new Dock
                {
                    Id = 2
                },

                new Dock
                {
                    Id = 3
                },

                new Dock
                {
                    Id = 4
                },

                new Dock
                {
                    Id = 5
                },

                new Dock
                {
                    Id = 6
                },

                new Dock
                {
                    Id = 7
                },

                new Dock
                {
                    Id = 8
                },

                new Dock
                {
                    Id = 9
                },

                new Dock
                {
                    Id = 10
                }
            };

            var bikes = new[]
            {
                new Bike
                {
                    Id = 11,
                    Rented = false,
                    DockId = 1
                },

                new Bike
                {
                    Id = 12,
                    Rented = false,
                    DockId = 1
                },

                new Bike
                {
                    Id = 13,
                    Rented = false,
                    DockId = 1
                },

                new Bike
                {
                    Id = 21,
                    Rented = false,
                    DockId = 2
                },

                new Bike
                {
                    Id = 22,
                    Rented = false,
                    DockId = 2
                },

                new Bike
                {
                    Id = 23,
                    Rented = false,
                    DockId = 2
                },

                new Bike
                {
                    Id = 31,
                    Rented = false,
                    DockId = 3
                },

                new Bike
                {
                    Id = 32,
                    Rented = false,
                    DockId = 3
                },

                new Bike
                {
                    Id = 33,
                    Rented = false,
                    DockId = 3
                },

                new Bike
                {
                    Id = 41,
                    Rented = false,
                    DockId = 4
                },

                new Bike
                {
                    Id = 42,
                    Rented = false,
                    DockId = 4
                },

                new Bike
                {
                    Id = 43,
                    Rented = false,
                    DockId = 4
                },

                new Bike
                {
                    Id = 51,
                    Rented = false,
                    DockId = 5
                },

                new Bike
                {
                    Id = 52,
                    Rented = false,
                    DockId = 5
                },

                new Bike
                {
                    Id = 53,
                    Rented = false,
                    DockId = 5
                },

                new Bike
                {
                    Id = 61,
                    Rented = false,
                    DockId = 6
                },

                new Bike
                {
                    Id = 62,
                    Rented = false,
                    DockId = 6
                },

                new Bike
                {
                    Id = 63,
                    Rented = false,
                    DockId = 6
                },

                new Bike
                {
                    Id = 71,
                    Rented = false,
                    DockId = 7
                },

                new Bike
                {
                    Id = 72,
                    Rented = false,
                    DockId = 7
                },

                new Bike
                {
                    Id = 73,
                    Rented = false,
                    DockId = 7
                },

                new Bike
                {
                    Id = 81,
                    Rented = false,
                    DockId = 8
                },

                new Bike
                {
                    Id = 82,
                    Rented = false,
                    DockId = 8
                },

                new Bike
                {
                    Id = 83,
                    Rented = false,
                    DockId = 8
                },

                new Bike
                {
                    Id = 91,
                    Rented = false,
                    DockId = 9
                },

                new Bike
                {
                    Id = 92,
                    Rented = false,
                    DockId = 9
                },

                new Bike
                {
                    Id = 93,
                    Rented = false,
                    DockId = 9
                },

                new Bike
                {
                    Id = 101,
                    Rented = false,
                    DockId = 10 
                },

                new Bike
                {
                    Id = 102,
                    Rented = false,
                    DockId = 10
                },

                new Bike
                {
                    Id = 103,
                    Rented = false,
                    DockId = 10
                },
            };

            var creditCard = new[]
            {
                new CreditCard
                {
                    CardHolderName = "Seth Richard",
                    CCNumber = "2222000011110000",
                    ExpDate = new System.DateTime(2025, 3, 1),
                    SecurityNumber = 420,
                    Address = "123 Rat Road, Baker LA  70714",
                    Valid = true,
                },
                new CreditCard
                {
                    CardHolderName = "Invalid Card",
                    CCNumber = "0000000000000000",
                    ExpDate = new System.DateTime(2020, 3, 1),
                    SecurityNumber = 123,
                    Address = "Doesn't Matter St.",
                    Valid = false,
                }
            };

            modelBuilder.Entity<Dock>().HasData(docks);
            modelBuilder.Entity<Bike>().HasData(bikes);
            modelBuilder.Entity<CreditCard>().HasData(creditCard);

            base.OnModelCreating(modelBuilder);
        }
    }
}
