using FlightControlDB.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
namespace FlightControlDB
{
    public class DataContext : DbContext
    {
        //public virtual DbSet<Flight> Flights { get; set; }
        //public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //public DataContext(string connectionString) : base(GetOptions(connectionString)) { }

        //private static DbContextOptions<DataContext> GetOptions(string connectionString)
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        //    optionsBuilder.UseSqlServer(connectionString);
        //    return optionsBuilder.Options;
        //}

        //public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Leg> Legs { get; set; }
        public virtual DbSet<Logger> Loggers { get; set; }

        //public DataContext() : base("AirPort") { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Leg>().HasData(
                  new Leg { Id = 1, IsEmpty = true, WaitTime = 3, IsChangeStatus = false, CurrentLeg = LegNumber.One, NextLegs = LegNumber.Two },
                  new Leg { Id = 2, IsEmpty = true, WaitTime = 5, IsChangeStatus = false, CurrentLeg = LegNumber.Two, NextLegs = LegNumber.Three },
                  new Leg { Id = 3, IsEmpty = true, WaitTime = 6, IsChangeStatus = false, CurrentLeg = LegNumber.Three, NextLegs = LegNumber.Four },
                  new Leg { Id = 4, IsEmpty = true, WaitTime = 8, IsChangeStatus = false, CurrentLeg = LegNumber.Four, NextLegs = LegNumber.Five | LegNumber.Departure },
                  //new Leg { Id = 4, IsEmpty = true, WaitTime = 8, IsChangeStatus = false, CurrentLeg = LegNumber.Fou, NextLegs = LegNumber.Fiv},
                  new Leg { Id = 5, IsEmpty = true, WaitTime = 4, IsChangeStatus = false, CurrentLeg = LegNumber.Five, NextLegs = LegNumber.Seven | LegNumber.Six },
                  new Leg { Id = 6, IsEmpty = true, WaitTime = 7, IsChangeStatus = true, CurrentLeg = LegNumber.Six, NextLegs = LegNumber.Eight },
                  new Leg { Id = 7, IsEmpty = true, WaitTime = 8, IsChangeStatus = true, CurrentLeg = LegNumber.Seven, NextLegs = LegNumber.Eight },
                  new Leg { Id = 8, IsEmpty = true, WaitTime = 2, IsChangeStatus = true, CurrentLeg = LegNumber.Eight, NextLegs = LegNumber.Four | LegNumber.ForDeparture},
                  new Leg { Id = 9, IsEmpty = true, WaitTime = 2, IsChangeStatus = true, CurrentLeg = LegNumber.Departure, NextLegs = LegNumber.One }
                );

            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

        }
        //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder("Server=(localdb)\\mssqllocaldb;Database=MyAirport;Trusted_Connection=True;TrustServerCertificate=true;");

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MyAirport;Trusted_Connection=True;TrustServerCertificate=true;");
        //    Console.WriteLine("**************************************************************************\nIn Config\n**************************************************************************");
        //}

        //public DataContext() : base() { }

    }
}