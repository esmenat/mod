﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SistemaDeVentasDeTicketsDeTrenIbarra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemaTickets.Modelos.Admin", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("SistemaTickets.Modelos.Client", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("SistemaTickets.Modelos.Reservation", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ClientCodigo")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Codigo");

                    b.HasIndex("ClientCodigo");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("SistemaTickets.Modelos.Route", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TravelTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Route");
                });

            modelBuilder.Entity("SistemaTickets.Modelos.Seat", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TicketCodigo")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("TypePriceForUserCodigo")
                        .HasColumnType("int");

                    b.HasKey("Codigo");

                    b.HasIndex("TicketCodigo");

                    b.HasIndex("TypePriceForUserCodigo");

                    b.ToTable("Seat");
                });

            modelBuilder.Entity("SistemaTickets.Modelos.Ticket", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<DateTime>("AssignedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PurchasDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReservationCodigo")
                        .HasColumnType("int");

                    b.Property<int>("RouteCodigo")
                        .HasColumnType("int");

                    b.HasKey("Codigo");

                    b.HasIndex("ReservationCodigo");

                    b.HasIndex("RouteCodigo");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("SistemaTickets.Modelos.TypePriceForUser", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Codigo");

                    b.ToTable("TypePriceForUser");
                });

            modelBuilder.Entity("SistemaTickets.Modelos.Reservation", b =>
                {
                    b.HasOne("SistemaTickets.Modelos.Client", "Client")
                        .WithMany("Reservations")
                        .HasForeignKey("ClientCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("SistemaTickets.Modelos.Seat", b =>
                {
                    b.HasOne("SistemaTickets.Modelos.Ticket", "Ticket")
                        .WithMany("Seats")
                        .HasForeignKey("TicketCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SistemaTickets.Modelos.TypePriceForUser", "TypePriceForUser")
                        .WithMany("Seats")
                        .HasForeignKey("TypePriceForUserCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Ticket");

                    b.Navigation("TypePriceForUser");
                });

            modelBuilder.Entity("SistemaTickets.Modelos.Ticket", b =>
                {
                    b.HasOne("SistemaTickets.Modelos.Reservation", "Reservation")
                        .WithMany("Tickets")
                        .HasForeignKey("ReservationCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SistemaTickets.Modelos.Route", "Route")
                        .WithMany("Tickets")
                        .HasForeignKey("RouteCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Reservation");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("SistemaTickets.Modelos.Client", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("SistemaTickets.Modelos.Reservation", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("SistemaTickets.Modelos.Route", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("SistemaTickets.Modelos.Ticket", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("SistemaTickets.Modelos.TypePriceForUser", b =>
                {
                    b.Navigation("Seats");
                });
#pragma warning restore 612, 618
        }
    }
}
