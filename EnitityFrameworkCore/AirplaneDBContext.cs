using EnitityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EnitityFrameworkCore
{
    public class AirplaneDBContext : DbContext
    {
        public AirplaneDBContext()
        {
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
        }
        //Collection

        public DbSet<Client> Clients { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
                                        Initial Catalog=AirplaneeDB2;
                                        Integrated Security=True;
                                        Connect Timeout=5;
                                        Encrypt=False;
                                        Trust Server Certificate=False;
                                        Application Intent=ReadWrite;
                                        Multi Subnet Failover=False");
        }
        //Client
        //Flight
        //Airplanes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Fluent api configuration
            //modelBuilder.Entity<Airplane>().Property(nameof(Model));
            modelBuilder.Entity<Airplane>()
                .Property(a=>a.Model)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Client>().ToTable("Passengers");
            modelBuilder.Entity<Client>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("FirstName");

            modelBuilder.Entity<Client>()
                .Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Flight>()
                .HasKey(f=>f.Id);
            modelBuilder.Entity<Flight>()
                .Property(c=>c.DepartureSity)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Flight>()
                .Property(c => c.ArrivalSity)
                .IsRequired()
                .HasMaxLength(100);

            /*One to many (1....*) */
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Airplane)
                .WithMany(a=>a.Flights)
                .HasForeignKey(a => a.AirplaneId);
            /*Many to many (*....*) */
            modelBuilder.Entity<Flight>()
                .HasMany(f => f.Clients)
                .WithMany(c => c.Flights);
            //Initializator - seeder
            modelBuilder.Entity<Airplane>().HasData(new Airplane[]
            {
                 new Airplane()
                {
                    Id = 1,
                    Model = "boing747",
                    MaxPassengers = 300,
                },
                new Airplane()
                {
                    Id = 2,
                    Model = "An914",
                    MaxPassengers = 200,
                },
                 new Airplane()
                {
                    Id = 3,
                    Model = "Mria",
                    MaxPassengers = 150,
                }
            });
            modelBuilder.Entity<Flight>().HasData(new Flight[]
            {
                new Flight()
                {
                    Id = 1,
                    DepartureSity = "Kyiv",
                    ArrivalSity = "Lviv",
                    DepartureTime = new DateTime(2024,2,17),
                    ArrivalTime = new DateTime(2024,2,17),
                    AirplaneId = 1
                },
                 new Flight()
                {
                    Id = 2,
                    DepartureSity = "Warshawa",
                    ArrivalSity = "Lviv",
                    DepartureTime = new DateTime(2024,2,18),
                    ArrivalTime = new DateTime(2024,2,18),
                    AirplaneId = 2
                },
                new Flight()
                {
                    Id = 3,
                    DepartureSity = "Kyiv",
                    ArrivalSity = "Lviv",
                    DepartureTime = new DateTime(2024,2,22),
                    ArrivalTime = new DateTime(2024,2,22),
                    AirplaneId = 3
                },


            });
        }
    }
}
