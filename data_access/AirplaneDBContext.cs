using EnitityFrameworkCore.Entities;
using EnitityFrameworkCore.Helpers;
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
            
           modelBuilder.SeedAirplanes();
           modelBuilder.SeedFlights();
        }
    }
}
