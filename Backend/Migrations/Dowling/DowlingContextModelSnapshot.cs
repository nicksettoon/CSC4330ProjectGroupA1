﻿// <auto-generated />
using System;
using Backend.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Migrations.Dowling
{
    [DbContext(typeof(DowlingContext))]
    partial class DowlingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("Backend.Entities.Bike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DockId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Rented")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DockId");

                    b.ToTable("Bikes");

                    b.HasData(
                        new
                        {
                            Id = 11,
                            DockId = 1,
                            Rented = false
                        },
                        new
                        {
                            Id = 12,
                            DockId = 1,
                            Rented = false
                        },
                        new
                        {
                            Id = 13,
                            DockId = 1,
                            Rented = false
                        },
                        new
                        {
                            Id = 21,
                            DockId = 2,
                            Rented = false
                        },
                        new
                        {
                            Id = 22,
                            DockId = 2,
                            Rented = false
                        },
                        new
                        {
                            Id = 23,
                            DockId = 2,
                            Rented = false
                        },
                        new
                        {
                            Id = 31,
                            DockId = 3,
                            Rented = false
                        },
                        new
                        {
                            Id = 32,
                            DockId = 3,
                            Rented = false
                        },
                        new
                        {
                            Id = 33,
                            DockId = 3,
                            Rented = false
                        },
                        new
                        {
                            Id = 41,
                            DockId = 4,
                            Rented = false
                        },
                        new
                        {
                            Id = 42,
                            DockId = 4,
                            Rented = false
                        },
                        new
                        {
                            Id = 43,
                            DockId = 4,
                            Rented = false
                        },
                        new
                        {
                            Id = 51,
                            DockId = 5,
                            Rented = false
                        },
                        new
                        {
                            Id = 52,
                            DockId = 5,
                            Rented = false
                        },
                        new
                        {
                            Id = 53,
                            DockId = 5,
                            Rented = false
                        },
                        new
                        {
                            Id = 61,
                            DockId = 6,
                            Rented = false
                        },
                        new
                        {
                            Id = 62,
                            DockId = 6,
                            Rented = false
                        },
                        new
                        {
                            Id = 63,
                            DockId = 6,
                            Rented = false
                        },
                        new
                        {
                            Id = 71,
                            DockId = 7,
                            Rented = false
                        },
                        new
                        {
                            Id = 72,
                            DockId = 7,
                            Rented = false
                        },
                        new
                        {
                            Id = 73,
                            DockId = 7,
                            Rented = false
                        },
                        new
                        {
                            Id = 81,
                            DockId = 8,
                            Rented = false
                        },
                        new
                        {
                            Id = 82,
                            DockId = 8,
                            Rented = false
                        },
                        new
                        {
                            Id = 83,
                            DockId = 8,
                            Rented = false
                        },
                        new
                        {
                            Id = 91,
                            DockId = 9,
                            Rented = false
                        },
                        new
                        {
                            Id = 92,
                            DockId = 9,
                            Rented = false
                        },
                        new
                        {
                            Id = 93,
                            DockId = 9,
                            Rented = false
                        },
                        new
                        {
                            Id = 101,
                            DockId = 10,
                            Rented = false
                        },
                        new
                        {
                            Id = 102,
                            DockId = 10,
                            Rented = false
                        },
                        new
                        {
                            Id = 103,
                            DockId = 10,
                            Rented = false
                        });
                });

            modelBuilder.Entity("Backend.Entities.CreditCard", b =>
                {
                    b.Property<string>("CCNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CardHolderName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("SecurityNumber")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Valid")
                        .HasColumnType("INTEGER");

                    b.HasKey("CCNumber");

                    b.ToTable("CreditCards");

                    b.HasData(
                        new
                        {
                            CCNumber = "2222000011110000",
                            Address = "123 Rat Road, Baker LA  70714",
                            CardHolderName = "Seth Richard",
                            ExpDate = new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SecurityNumber = 420,
                            Valid = true
                        },
                        new
                        {
                            CCNumber = "0000000000000000",
                            Address = "Doesn't Matter St.",
                            CardHolderName = "Invalid Card",
                            ExpDate = new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SecurityNumber = 123,
                            Valid = false
                        });
                });

            modelBuilder.Entity("Backend.Entities.Dock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Docks");

                    b.HasData(
                        new
                        {
                            Id = 1
                        },
                        new
                        {
                            Id = 2
                        },
                        new
                        {
                            Id = 3
                        },
                        new
                        {
                            Id = 4
                        },
                        new
                        {
                            Id = 5
                        },
                        new
                        {
                            Id = 6
                        },
                        new
                        {
                            Id = 7
                        },
                        new
                        {
                            Id = 8
                        },
                        new
                        {
                            Id = 9
                        },
                        new
                        {
                            Id = 10
                        });
                });

            modelBuilder.Entity("Backend.Entities.Rental", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BikeNumber")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CheckInTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CheckOutTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsBikeDamaged")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("RentDock")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RenterEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ReturnDock")
                        .HasColumnType("INTEGER");

                    b.HasKey("Key");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("Backend.Entities.Bike", b =>
                {
                    b.HasOne("Backend.Entities.Dock", "Dock")
                        .WithMany("Bikes")
                        .HasForeignKey("DockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dock");
                });

            modelBuilder.Entity("Backend.Entities.Dock", b =>
                {
                    b.Navigation("Bikes");
                });
#pragma warning restore 612, 618
        }
    }
}
