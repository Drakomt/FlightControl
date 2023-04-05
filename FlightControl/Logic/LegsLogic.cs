//using FlightControl.Data;
//using FlightControl.Models;
using FlightControlDB;
using FlightControlDB.Models;
using FlightControlDB.Repositories;
//using FlightControl.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlightControl.Logic
{
    public class LegsLogic
    {
        //readonly Air air = Air.Init;

        private readonly IRepository _repository;
        //private readonly DataContext data;

        public Queue<Flight> inQueue = new Queue<Flight>();
        public Queue<Flight> inAirport = new Queue<Flight>();
        //public Queue<Flight> waitQueue = new Queue<Flight>();

        //public void AddFlight(Flight flight) => air.AddFlight(flight);

        LegNumber forDeparture;
        public LegsLogic(IRepository repository)
        {
            _repository = repository;

            FindLastForDepLeg();         //fix problem with the 2 calls to the db at the same time.
        }

        //public LegsLogic(DataContext data)
        //{
        //    this.data = data;
        //    //int legNum = 1;
        //    //switch (legNum)
        //    //{
        //    //    case 1: break; 
        //    //    case 2: break;
        //    //}
        //}

        //private void AddTerminalsToDb()
        //{
        //    var l1 = new Leg { Number = 1, WaitTime = 3, IsChangeStatus = false, CurrentLeg = LegNumber.One, NextLegs = LegNumber.Two };
        //    var l2 = new Leg { Number = 2, WaitTime = 5, IsChangeStatus = false, CurrentLeg = LegNumber.Two, NextLegs = LegNumber.Thr };
        //    var l3 = new Leg { Number = 3, WaitTime = 6, IsChangeStatus = false, CurrentLeg = LegNumber.Thr, NextLegs = LegNumber.Fou };
        //    var l4 = new Leg { Number = 4, WaitTime = 8, IsChangeStatus = false, CurrentLeg = LegNumber.Fou, NextLegs = LegNumber.Fiv | LegNumber.Dep };
        //    var l5 = new Leg { Number = 5, WaitTime = 4, IsChangeStatus = false, CurrentLeg = LegNumber.Fiv, NextLegs = LegNumber.Six | LegNumber.Sev };
        //    var l6 = new Leg { Number = 6, WaitTime = 7, IsChangeStatus = true, CurrentLeg = LegNumber.Six, NextLegs = LegNumber.Eig };
        //    var l7 = new Leg { Number = 7, WaitTime = 8, IsChangeStatus = true, CurrentLeg = LegNumber.Sev, NextLegs = LegNumber.Eig };
        //    var l8 = new Leg { Number = 8, WaitTime = 2, IsChangeStatus = true, CurrentLeg = LegNumber.Eig, NextLegs = LegNumber.Fou };
        //    data.Legs.AddRange(new List<Leg> { l1, l2, l3, l4, l5, l6, l7, l8 });
        //}
        //public async Task AddFlight(Flight flight)
        //{
        //    //var startLeg = await data.Legs.FirstOrDefaultAsync(l => l.CurrentLeg == LegNumber.One);
        //    var startLeg = await _repository.FirstLegAsync();
        //    startLeg.IsEmpty = false;
        //    await NextTerminal(flight, startLeg, 0);
        //}

        //public async Task NextTerminal(Flight flight, Leg leg)
        //{
        //    using var transaction = await data.Database.BeginTransactionAsync();

        //    try
        //    {
        //        var log = new Logger { Flight = flight, Leg = leg, In = DateTime.Now };
        //        await data.Loggers.AddAsync(log);
        //        //Console.WriteLine($"{flight.Pilot.Name}: {leg.CurrentLeg} ({DateTime.Now})");
        //        if (leg.CurrentLeg == LegNumber.One)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Green;
        //        }
        //        await Console.Out.WriteLineAsync($"{flight.Pilot.Name}: {leg.CurrentLeg} ({DateTime.Now})");
        //        Console.ResetColor();

        //        if (leg.CurrentLeg == LegNumber.Fou)
        //        {
        //            if (!leg.IsChangeStatus)
        //            {
        //                if (inAirport.Count == 4)
        //                {
        //                    Console.ForegroundColor = ConsoleColor.Red;
        //                    await Console.Out.WriteLineAsync($"Terminals are at full capacity");
        //                    Console.ResetColor();
        //                }
        //            }
        //            else
        //            {
        //                inAirport.Dequeue();
        //            }
        //        }

        //        Thread.Sleep(leg.WaitTime * 1000);
        //        var nextLeg = data.Legs.FirstOrDefault(l => leg.NextLegs.HasFlag(l.CurrentLeg));
        //        if (leg.CurrentLeg == LegNumber.Fou && flight.IsDeparture)
        //        {
        //            log.Out = DateTime.Now;
        //            leg.IsEmpty = true;
        //            flight.IsActive = false;
        //            Console.ForegroundColor = ConsoleColor.Green;
        //            await Console.Out.WriteLineAsync($"{flight.Pilot.Name}: Departure from {leg.CurrentLeg} ({DateTime.Now})");
        //            Console.ResetColor();
        //            await data.SaveChangesAsync();
        //            return;
        //        }
        //        else if (nextLeg.IsEmpty == true)
        //        {
        //            nextLeg.IsEmpty = false;
        //            leg.IsEmpty = true;
        //            log.Out = DateTime.Now;

        //            flight.IsDeparture = leg.IsChangeStatus;
        //        }

        //        await data.SaveChangesAsync();
        //        //using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        //        //{
        //        //    await NextTerminal(flight, nextLeg);
        //        //    scope.Complete();
        //        //}

        //        await transaction.CommitAsync();
        //        await NextTerminal(flight, nextLeg);

        //    }
        //    catch (Exception ex)
        //    {
        //        await transaction.RollbackAsync();
        //        await Console.Out.WriteLineAsync(ex.Message);
        //        // handle the exception
        //    }
        //}




        //public async Task NextTerminal(Flight flight, Leg leg)
        //{
        //    var log = new Logger { Flight = flight, Leg = leg, In = DateTime.Now };
        //    //await data.Loggers.AddAsync(log);
        //    await _repository.AddLoggerAsync(log);


        //    //Console.WriteLine($"{flight.Pilot.Name}: {leg.CurrentLeg} ({DateTime.Now})");
        //    if (leg.CurrentLeg == LegNumber.One)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Green;
        //    }
        //    await Console.Out.WriteLineAsync($"{flight.Pilot.Name}: {leg.CurrentLeg} ({DateTime.Now})");
        //    Console.ResetColor();

        //    if (leg.CurrentLeg == LegNumber.Fou)
        //    {
        //        if (!leg.IsChangeStatus)
        //        {
        //            if (inAirport.Count == 4)
        //            {
        //                Console.ForegroundColor = ConsoleColor.Red;
        //                await Console.Out.WriteLineAsync($"Terminals are at full capacity");
        //                Console.ResetColor();
        //            }
        //        }
        //        else
        //        {
        //            inAirport.Dequeue();
        //        }
        //    }

            
        //    Thread.Sleep(leg.WaitTime * 1000);
        //    //var nextLeg = data.Legs.FirstOrDefault(l => leg.NextLegs.HasFlag(l.CurrentLeg));                                              //last one

        //    var nextLeg = await _repository.NextLegAsync(leg);

        //    if (leg.CurrentLeg == LegNumber.Fou && flight.IsDeparture)
        //    {
        //        log.Out = DateTime.Now;
        //        leg.IsEmpty = true;
        //        flight.IsActive = false;
        //        Console.ForegroundColor = ConsoleColor.Green;
        //        await Console.Out.WriteLineAsync($"{flight.Pilot.Name}: Departure from {leg.CurrentLeg} ({DateTime.Now})");
        //        Console.ResetColor();
        //        //await data.SaveChangesAsync();
        //        await _repository.SaveAsync();
        //        return;
        //    }
        //    else if (nextLeg.IsEmpty == true)
        //    {
        //        nextLeg.IsEmpty = false;
        //        leg.IsEmpty = true;
        //        log.Out = DateTime.Now;

        //        flight.IsDeparture = leg.IsChangeStatus;
        //    }

        //    //await data.SaveChangesAsync();
        //    await _repository.SaveAsync();

        //    //using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        //    //{
        //    //    await NextTerminal(flight, nextLeg);
        //    //    scope.Complete();
        //    //}

        //    await NextTerminal(flight, nextLeg);

        //}


        //private static readonly object _dbContextLock = new object();

        public async Task NextTerminal(Flight flight, Leg leg, Logger? log)
        {
            //DateTime dateIn = DateTime.Now;
            //var newLog = new Logger { Flight = flight, Leg = leg, In = dateIn };



            //await data.Loggers.AddAsync(log);



            //await _repository.AddLoggerAsync(log);



            //await _repository.SaveAsync();
            //Console.WriteLine($"{flight.Pilot.Name}: {leg.CurrentLeg} ({DateTime.Now})");

            //await Task.Delay(leg.WaitTime * 1000);
            if(log == null)
            {
                log = new Logger { Flight = flight, Leg = leg, In = DateTime.Now };
                //if (leg.CurrentLeg == LegNumber.One)
                //{
                //    Console.ForegroundColor = ConsoleColor.Green;
                //}
                Console.ForegroundColor = ConsoleColor.Green;
                await Console.Out.WriteLineAsync($"{flight.Pilot.Name}: {leg.CurrentLeg} ({DateTime.Now})");
                Console.ResetColor();
                Thread.Sleep(leg.WaitTime * 1000);
            }
            else
            {

            }
            //var nextLeg = data.Legs.FirstOrDefault(l => leg.NextLegs.HasFlag(l.CurrentLeg));

            var nextLegs = await _repository.NextLegsAsync(leg);
            Console.ForegroundColor = ConsoleColor.Red;
            await Console.Out.WriteLineAsync($"******************\n{nextLegs.Count}\n******************");
            Console.ResetColor();



            foreach(Leg nextLeg in nextLegs)
            {
                if (leg.NextLegs == LegNumber.Departure && flight.IsDeparture)
                {
                    //var currentLog = await _repository.GetLogAsync(dateIn, flight.Id);
                    //currentLog.Out = DateTime.Now;
                    log.Out = DateTime.Now;
                    leg.IsEmpty = true;
                    flight.IsActive = false;
                    inAirport.Dequeue();
                    Console.ForegroundColor = ConsoleColor.Green;
                    await Console.Out.WriteLineAsync($"{flight.Pilot.Name}: Departure from {leg.CurrentLeg} ({DateTime.Now})");
                    Console.ResetColor();
                    //lock (_dbContextLock)
                    //{
                    //    //await data.SaveChangesAsync();
                    //    _repository.Save();
                    //}
                    //_repository.Save();
                    await _repository.AddLoggerAsync(log);
                    await _repository.SaveAsync();
                    return;
                }
                else if (nextLeg.IsEmpty == true && !flight.IsDeparture)
                {

                    if (leg.CurrentLeg == forDeparture)
                    {
                        flight.IsDeparture = true;
                    }

                    //var currentLog = await _repository.GetLogAsync(dateIn, flight.Id);
                    //currentLog.Out = DateTime.Now;
                    nextLeg.IsEmpty = false;
                    leg.IsEmpty = true;
                    log.Out = DateTime.Now;

                    //flight.IsDeparture = leg.IsChangeStatus;

                    await _repository.AddLoggerAsync(log);
                    await _repository.SaveAsync();
                    await NextTerminal(flight, nextLeg, null);
                }
                //else if (nextLegs.IsEmpty == false)
                //{
                //    Thread.Sleep(3000);
                //    await NextTerminal(flight, leg, log);
                //}
            }


            Thread.Sleep(3000);
            await NextTerminal(flight, leg, log);



            //if (leg.CurrentLeg == LegNumber.Fou && flight.IsDeparture)
            //{
            //    //var currentLog = await _repository.GetLogAsync(dateIn, flight.Id);
            //    //currentLog.Out = DateTime.Now;
            //    log.Out = DateTime.Now;
            //    leg.IsEmpty = true;
            //    flight.IsActive = false;
            //    inAirport.Dequeue();
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    await Console.Out.WriteLineAsync($"{flight.Pilot.Name}: Departure from {leg.CurrentLeg} ({DateTime.Now})");
            //    Console.ResetColor();
            //    //lock (_dbContextLock)
            //    //{
            //    //    //await data.SaveChangesAsync();
            //    //    _repository.Save();
            //    //}
            //    //_repository.Save();
            //    await _repository.AddLoggerAsync(log);
            //    await _repository.SaveAsync();
            //    return;
            //}
            //else if (nextLeg.IsEmpty == true)
            //{
            //    //var currentLog = await _repository.GetLogAsync(dateIn, flight.Id);
            //    //currentLog.Out = DateTime.Now;
            //    nextLeg.IsEmpty = false;
            //    leg.IsEmpty = true;
            //    log.Out = DateTime.Now;

            //    flight.IsDeparture = leg.IsChangeStatus;

            //    await _repository.AddLoggerAsync(log);
            //    await _repository.SaveAsync();
            //    await NextTerminal(flight, nextLegs, null);
            //}
            //else if(nextLegs.IsEmpty == false) 
            //{
            //    Thread.Sleep(3000);
            //    await NextTerminal(flight, leg, log);
            //}






            //lock (_dbContextLock)
            //{
            //    //await data.SaveChangesAsync();
            //    _repository.Save();
            //}
            //_repository.Save();
            //using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            //{
            //    await NextTerminal(flight, nextLeg);
            //    scope.Complete();
            //}

            //await _repository.SaveAsync();
            //await NextTerminal(flight, nextLeg,0);
        }



        private async void FindLastForDepLeg()
        {
            var legs = await _repository.GetLegsAsync();
            foreach(Leg leg in legs)
            {
                if (leg.NextLegs.HasFlag(LegNumber.ForDeparture))
                {
                    forDeparture = leg.CurrentLeg;
                }
            }
        }



        //public async Task NextTerminal(Flight flight, Leg leg)
        //{
        //    var log = new Logger { Flight = flight, Leg = leg, In = DateTime.Now };
        //    data.Loggers.Add(log);
        //    Console.WriteLine($"{flight.Pilot.Name}: {leg.CurrentLeg} ({DateTime.Now})");

        //    Thread.Sleep(leg.WaitTime * 1000);
        //    var nextLeg = data.Legs.FirstOrDefault(l => leg.NextLegs.HasFlag(l.CurrentLeg));
        //    if (leg.CurrentLeg == LegNumber.Fou && flight.IsDeparture)
        //    {
        //        log.Out = DateTime.Now;
        //        leg.IsEmpty = true;
        //        flight.IsActive = false;
        //        inAirport.Dequeue();
        //        Console.WriteLine($"{flight.Pilot.Name}: Departure from {leg.CurrentLeg}");
        //        //data.Remove(flight);
        //        //data.Entry(flight).State = EntityState.Deleted;
        //        data.SaveChanges();
        //        //Controllers.FlightsController.PlanesInRunway--;
        //        return;
        //    }
        //    else if (nextLeg.IsEmpty == true)
        //    {
        //        nextLeg.IsEmpty = false;
        //        leg.IsEmpty = true;
        //        log.Out = DateTime.Now;

        //        flight.IsDeparture = leg.IsChangeStatus;
        //    }
        //    data.SaveChanges();

        //    await NextTerminal(flight, nextLeg);
        //}








        //public void NextTerminal(Flight flight, Leg leg)
        //{
        //    var log = new Logger { Flight = flight, Leg = leg, In = DateTime.Now };
        //    data.Loggers.Add(log);
        //    Console.WriteLine($"{flight.Pilot.Name}: {leg.Number} ({DateTime.Now})");

        //    Thread.Sleep(leg.WaitTime * 1000);
        //    var nextLeg = data.Legs.FirstOrDefault(l => leg.NextLegs.HasFlag(l.CurrentLeg));
        //    if (leg.CurrentLeg == LegNumber.Fou && flight.IsDeparture)
        //    {
        //        log.Out = DateTime.Now;
        //        leg.Flight = null;
        //        flight.IsActive = false;
        //        Console.WriteLine($"{flight.Pilot.Name}: Departure from {leg.Number}");
        //        //data.Remove(flight);
        //        //data.Entry(flight).State = EntityState.Deleted;
        //        data.SaveChanges();
        //        //Controllers.FlightsController.PlanesInRunway--;
        //        return;
        //    }
        //    else if (nextLeg.Flight == null)
        //    {
        //        nextLeg.Flight = flight;
        //        leg.Flight = null;
        //        log.Out = DateTime.Now;

        //        flight.IsDeparture = leg.IsChangeStatus;
        //    }
        //    data.SaveChanges();

        //    NextTerminal(flight, nextLeg);
        //}
    }
















    //public abstract class Leg
    //{
    //    public virtual int TimeToWait => 6;
    //    public Leg? NextLeg { get; set; }
    //    public Flight? Flight { get; set; }
    //    public virtual void AddFlight(Flight flight)
    //    {
    //        Flight = flight;
    //        NextTerminal(flight);
    //    }

    //    public void NextTerminal(Flight flight)
    //    {
    //        Thread.Sleep(TimeToWait * 10 * flight.Id);

    //        if (NextLeg!.Flight == null)
    //        {
    //            Debug.Print($"{flight.Id} = {GetType().Name}");
    //            NextLeg.AddFlight(flight);
    //            Flight = null;
    //        }
    //        else
    //        {
    //            NextTerminal(flight);
    //        }
    //    }
    //}

    //public class Air : Leg
    //{
    //    public static Air Init { get; } = new Air();
    //    private Air() => NextLeg = Leg1.Init;

    //    static readonly Queue<Flight> flights = new Queue<Flight>();

    //    public override void AddFlight(Flight flight)
    //    {
    //        flights.Enqueue(flight);

    //        if (NextLeg!.Flight == null)
    //            NextTerminal(flights.Dequeue());
    //    }
    //}

    //public class Leg1 : Leg
    //{
    //    public override int TimeToWait => 8;
    //    #region Singelton SIMPLE
    //    public static Leg1 Init { get; } = new Leg1();
    //    #endregion
    //    private Leg1() => NextLeg = Leg2.Init;
    //}

    //public class Leg2 : Leg
    //{
    //    public override int TimeToWait => 9;
    //    #region Singleton Less Code
    //    private static Leg2 init;
    //    public static Leg2 Init
    //    {
    //        get
    //        {
    //            init ??= new Leg2();
    //            return init;
    //        }
    //    }
    //    #endregion

    //    private Leg2() => NextLeg = Leg3.Init;
    //}

    //public class Leg3 : Leg
    //{
    //    public override int TimeToWait => 12;
    //    #region Singleton FULL
    //    private static Leg3 init;
    //    public static Leg3 Init
    //    {
    //        get
    //        {
    //            if (init == null)
    //                init = new Leg3();
    //            return init;
    //        }
    //    }
    //    #endregion

    //    private Leg3() { }
    //    public override void AddFlight(Flight flight)
    //    {
    //        Flight = null;
    //    }
    //}







    //if (leg.CurrentLeg == LegNumber.Fou)
    //{
    //    if (!leg.IsChangeStatus)
    //    {
    //        if (inAirport.Count == 4)
    //        {
    //            Console.ForegroundColor = ConsoleColor.Red;
    //            await Console.Out.WriteLineAsync($"Terminals are at full capacity");
    //            Console.ResetColor();
    //        }
    //    }
    //    else
    //    {
    //        inAirport.Dequeue();
    //    }
    //}
}
