﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebUI.Database;

#nullable disable

namespace WebUI.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250106143011_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Database.Models.Animal", b =>
                {
                    b.Property<Guid>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DietaryNotes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicalNotes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("AnimalId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Database.Models.AnimalPenBooking", b =>
                {
                    b.Property<Guid>("AnimalPenBookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnimalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PenBookingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AnimalPenBookingId");

                    b.HasIndex("AnimalId");

                    b.HasIndex("PenBookingId");

                    b.ToTable("AnimalPenBookings");
                });

            modelBuilder.Entity("Database.Models.Booking", b =>
                {
                    b.Property<Guid>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Cancelled")
                        .HasColumnType("bit");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("BookingId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Database.Models.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Database.Models.Pen", b =>
                {
                    b.Property<Guid>("PenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("CostPerNight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("MaxOccupancy")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("PenId");

                    b.ToTable("Pens");
                });

            modelBuilder.Entity("Database.Models.PenBooking", b =>
                {
                    b.Property<Guid>("PenBookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PenId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PenBookingId");

                    b.HasIndex("BookingId");

                    b.HasIndex("PenId");

                    b.ToTable("PenBookings");
                });

            modelBuilder.Entity("Database.Models.Animal", b =>
                {
                    b.HasOne("Database.Models.Customer", "Customer")
                        .WithMany("Animals")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Database.Models.AnimalPenBooking", b =>
                {
                    b.HasOne("Database.Models.Animal", "Animal")
                        .WithMany("AnimalPenBookings")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Database.Models.PenBooking", "PenBooking")
                        .WithMany("AnimalPenBookings")
                        .HasForeignKey("PenBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("PenBooking");
                });

            modelBuilder.Entity("Database.Models.Booking", b =>
                {
                    b.HasOne("Database.Models.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Database.Models.PenBooking", b =>
                {
                    b.HasOne("Database.Models.Booking", "Booking")
                        .WithMany("PenBookings")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.Pen", "Pen")
                        .WithMany("PenBookings")
                        .HasForeignKey("PenId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Pen");
                });

            modelBuilder.Entity("Database.Models.Animal", b =>
                {
                    b.Navigation("AnimalPenBookings");
                });

            modelBuilder.Entity("Database.Models.Booking", b =>
                {
                    b.Navigation("PenBookings");
                });

            modelBuilder.Entity("Database.Models.Customer", b =>
                {
                    b.Navigation("Animals");

                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Database.Models.Pen", b =>
                {
                    b.Navigation("PenBookings");
                });

            modelBuilder.Entity("Database.Models.PenBooking", b =>
                {
                    b.Navigation("AnimalPenBookings");
                });
#pragma warning restore 612, 618
        }
    }
}
