﻿// <auto-generated />
using System;
using Backend.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Migrations
{
    [DbContext(typeof(DowlingContext))]
    partial class DowlingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Backend.Entities.Bike", b =>
                {
                    b.Property<int>("BikeNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Rented")
                        .HasColumnType("INTEGER");

                    b.HasKey("BikeNumber");

                    b.ToTable("Bikes");
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

                    b.HasKey("CCNumber");

                    b.ToTable("CreditCards");
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

                    b.Property<string>("RenterEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Key");

                    b.ToTable("Rentals");
                });
#pragma warning restore 612, 618
        }
    }
}
