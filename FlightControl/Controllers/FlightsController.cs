//using FlightControl.Data;
using FlightControl.Logic;
//using FlightControl.Models;
//using FlightControl.Repositories;
using FlightControlDB.Models;
using FlightControlDB.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        //public static int PlanesInRunway = 0;
        //private readonly DataContext data;
        private readonly IRepository _repository;
        private readonly LegsLogic _logic;
        //private static readonly object _dbControllerLock = new object();

        public FlightsController(IRepository repository/*, LegsLogic logic*/)
        {
            //this.data = data;
            _repository = repository;
            //_logic = logic;
            _logic = new LegsLogic(repository);
        }

        //[HttpGet]
        //public async Task<List<Logger>> Get() => await data.Loggers.Include(l => l.Flight).ThenInclude(f => f.Pilot).Include(l => l.Leg).ToListAsync();

        [HttpGet]
        public async Task<List<Logger>> Get() => await _repository.LoggerListAsync();

        [HttpPost]
        public async Task AddFlight(Flight flight)
        {
            //await data.Flights.AddAsync(flight);
            await _repository.AddFlightAsync(flight);
            await _repository.SaveAsync();
            _logic.inQueue.Enqueue(flight);
            
            while(_logic.inQueue.Count > 0)
            {
                var startLeg = await _repository.FirstLegAsync();
                if (startLeg.IsEmpty && _logic.inAirport.Count < 4)
                {
                    Flight fQueue = _logic.inQueue.Dequeue();
                    _logic.inAirport.Enqueue(fQueue);
                    //await _repository.SaveAsync();
                    //lock (_dbControllerLock)
                    //{
                    //    //await data.SaveChangesAsync();
                    //    _repository.Save();
                    //}
                    //_repository.Save();



                    //await _repository.SaveAsync();


                    //await _logic.AddFlight(fQueue);

                    await _logic.NextTerminal(flight, startLeg, null);
                }
            }



            //if(_logic.inAirport.Count < 4)
            //{
            //    Flight fQueue = _logic.inQueue.Dequeue();
            //    _logic.inAirport.Enqueue(fQueue);
            //    //await _repository.SaveAsync();
            //    //lock (_dbControllerLock)
            //    //{
            //    //    //await data.SaveChangesAsync();
            //    //    _repository.Save();
            //    //}
            //    //_repository.Save();



            //    //await _repository.SaveAsync();
            //    await _logic.AddFlight(fQueue);
            //}







            //else
            //{
            //    //lock (_dbControllerLock)
            //    //{
            //    //    //await data.SaveChangesAsync();
            //    //    _repository.Save();
            //    //}
            //    //_repository.Save();
            //    await _repository.SaveAsync();
            //}
            //await data.SaveChangesAsync();


            //var res = await data.SaveChangesAsync();
            //if (res > 0)
            //    lock (data)
            //        logic.NextTerminal(flight, data.Legs.FirstOrDefault(l => l.CurrentLeg == LegNumber.One));
            //return res;

        }

        //[HttpPost]
        //public async Task<int> AddFlight(Flight flight)
        //{
        //    //if(PlanesInRunway <= 4)
        //    //{
        //    //    PlanesInRunway++;
        //        await data.Flights.AddAsync(flight);
        //        var res = await data.SaveChangesAsync();
        //    if (res > 0)
        //        lock (data)
        //            logic.NextTerminal(flight, data.Legs.FirstOrDefault(l => l.CurrentLeg == LegNumber.One));
        //    return res;
        //    //}

        //    //return 0;
        //}



        //[HttpPost]
        //public async Task<int> AddFlight(Flight flight)
        //{
        //    await data.Flights.AddAsync(flight);
        //    var res = await data.SaveChangesAsync();
        //    if (res > 0)
        //        lock (data)
        //            logic.AddFlight(flight);
        //    return res;
        //}



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
    }
}
