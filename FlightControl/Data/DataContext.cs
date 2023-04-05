//using FlightControl.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Diagnostics;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//namespace FlightControl.Data
//{
//    public class DataContext : DbContext
//    {
//        //public virtual DbSet<Flight> Flights { get; set; }
//        //public DataContext(DbContextOptions<DataContext> options) : base(options) { }

//        public virtual DbSet<Flight> Flights { get; set; }
//        public virtual DbSet<Leg> Legs { get; set; }
//        public virtual DbSet<Logger> Loggers { get; set; }

//        //public DataContext() : base("AirPort") { }


//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Leg>().HasData(
//                  new Leg { Id = 1, IsEmpty = true, WaitTime = 3, IsChangeStatus = false, CurrentLeg = LegNumber.One, NextLegs = LegNumber.Two },
//                  new Leg { Id = 2, IsEmpty = true, WaitTime = 5, IsChangeStatus = false, CurrentLeg = LegNumber.Two, NextLegs = LegNumber.Thr },
//                  new Leg { Id = 3, IsEmpty = true, WaitTime = 6, IsChangeStatus = false, CurrentLeg = LegNumber.Thr, NextLegs = LegNumber.Fou },
//                  new Leg { Id = 4, IsEmpty = true, WaitTime = 8, IsChangeStatus = false, CurrentLeg = LegNumber.Fou, NextLegs = LegNumber.Fiv | LegNumber.Dep },
//                  new Leg { Id = 5, IsEmpty = true, WaitTime = 4, IsChangeStatus = false, CurrentLeg = LegNumber.Fiv, NextLegs = LegNumber.Six | LegNumber.Sev },
//                  new Leg { Id = 6, IsEmpty = true, WaitTime = 7, IsChangeStatus = true, CurrentLeg = LegNumber.Six, NextLegs = LegNumber.Eig },
//                  new Leg { Id = 7, IsEmpty = true, WaitTime = 8, IsChangeStatus = true, CurrentLeg = LegNumber.Sev, NextLegs = LegNumber.Eig },
//                  new Leg { Id = 8, IsEmpty = true, WaitTime = 2, IsChangeStatus = true, CurrentLeg = LegNumber.Eig, NextLegs = LegNumber.Fou }
//                );
//        }

//        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
//    }
//}
