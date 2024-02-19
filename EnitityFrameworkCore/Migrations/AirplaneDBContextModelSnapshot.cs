﻿// <auto-generated />
using System;
using EnitityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EnitityFrameworkCore.Migrations
{
    [DbContext(typeof(AirplaneDBContext))]
    partial class AirplaneDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClientFlight", b =>
                {
                    b.Property<int>("ClientsId")
                        .HasColumnType("int");

                    b.Property<int>("FlightsId")
                        .HasColumnType("int");

                    b.HasKey("ClientsId", "FlightsId");

                    b.HasIndex("FlightsId");

                    b.ToTable("ClientFlight");
                });

            modelBuilder.Entity("EnitityFrameworkCore.Entities.Airplane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MaxPassengers")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Airplanes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MaxPassengers = 300,
                            Model = "boing747"
                        },
                        new
                        {
                            Id = 2,
                            MaxPassengers = 200,
                            Model = "An914"
                        },
                        new
                        {
                            Id = 3,
                            MaxPassengers = 150,
                            Model = "Mria"
                        });
                });

            modelBuilder.Entity("EnitityFrameworkCore.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("FirstName");

                    b.HasKey("Id");

                    b.ToTable("Passangers");
                });

            modelBuilder.Entity("EnitityFrameworkCore.Entities.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AirplaneId")
                        .HasColumnType("int");

                    b.Property<string>("ArrivalSity")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartureSity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AirplaneId");

                    b.ToTable("Flights");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AirplaneId = 1,
                            ArrivalSity = "Lviv",
                            ArrivalTime = new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartureSity = "Kyiv",
                            DepartureTime = new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            AirplaneId = 2,
                            ArrivalSity = "Lviv",
                            ArrivalTime = new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartureSity = "Warshawa",
                            DepartureTime = new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            AirplaneId = 3,
                            ArrivalSity = "Lviv",
                            ArrivalTime = new DateTime(2024, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartureSity = "Kyiv",
                            DepartureTime = new DateTime(2024, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ClientFlight", b =>
                {
                    b.HasOne("EnitityFrameworkCore.Entities.Client", null)
                        .WithMany()
                        .HasForeignKey("ClientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnitityFrameworkCore.Entities.Flight", null)
                        .WithMany()
                        .HasForeignKey("FlightsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EnitityFrameworkCore.Entities.Flight", b =>
                {
                    b.HasOne("EnitityFrameworkCore.Entities.Airplane", "Airplane")
                        .WithMany("Flights")
                        .HasForeignKey("AirplaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airplane");
                });

            modelBuilder.Entity("EnitityFrameworkCore.Entities.Airplane", b =>
                {
                    b.Navigation("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}
