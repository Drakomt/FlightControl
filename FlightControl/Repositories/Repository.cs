//using FlightControl.Data;
//using FlightControl.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;

//namespace FlightControl.Repositories
//{
//    public class Repository : IRepository
//    {
//        private static readonly object _dbLock = new object();
//        private readonly DataContext _data;
//        public Repository(DataContext data) 
//        {
//            _data= data;
//        }
//        public async Task AddFlightAsync(Flight flight)
//        {
//            //await _data.Flights.AddAsync(flight);

//            lock (_dbLock)
//            {
//                //_data.Flights.Add(flight);
//                _data.Flights.AddAsync(flight);
//            }
//        }

//        public async Task AddLoggerAsync(Logger logger)
//        {
//            //await _data.Loggers.AddAsync(logger);

//            lock (_dbLock)
//            {
//                //_data.Loggers.Add(logger);
//                _data.Loggers.AddAsync(logger);
//            }
//        }

//        public async Task<Leg> FirstLegAsync()
//        {
//            //return await _data.Legs.FirstAsync(l => l.CurrentLeg == LegNumber.One);

//            Task<Leg> res;
//            lock (_dbLock)
//            {
//                res = _data.Legs.FirstAsync(l => l.CurrentLeg == LegNumber.One);

//            }
//            return res.Result;
//        }


//        //public async Task<Leg> FirstLegAsync()
//        //{
//        //    //return await _data.Legs.FirstAsync(l => l.CurrentLeg == LegNumber.One);

//        //    Leg res;
//        //    lock (_dbLock)
//        //    {
//        //        res = _data.Legs.First(l => l.CurrentLeg == LegNumber.One);

//        //    }
//        //    return res;
//        //}

//        public async Task<List<Logger>> LoggerListAsync()
//        {
//            //return await _data.Loggers.Include(l => l.Leg).Include(l => l.Flight).ToListAsync();

//            Task<List<Logger>> res;
//            lock (_dbLock)
//            {
//                res = _data.Loggers.Include(l => l.Leg).Include(l => l.Flight).ToListAsync();

//            }
//            return res.Result;
//        }

//        //public async Task<List<Logger>> LoggerListAsync()
//        //{
//        //    //return await _data.Loggers.Include(l => l.Leg).Include(l => l.Flight).ToListAsync();

//        //    List<Logger> res;
//        //    lock (_dbLock)
//        //    {
//        //        res = _data.Loggers.Include(l => l.Leg).Include(l => l.Flight).ToList();

//        //    }
//        //    return res;
//        //}

//        public async Task<Leg> NextLegAsync(Leg leg)
//        {
//            //return await _data.Legs.FirstOrDefaultAsync(l => leg.NextLegs.HasFlag(l.CurrentLeg));

//            Task<Leg> res;
//            lock (_dbLock)
//            {
//                res = _data.Legs.FirstOrDefaultAsync(l => leg.NextLegs.HasFlag(l.CurrentLeg));

//            }
//            return res.Result;
//        }

//        //public async Task<Leg> NextLegAsync(Leg leg)
//        //{
//        //    //return await _data.Legs.FirstOrDefaultAsync(l => leg.NextLegs.HasFlag(l.CurrentLeg));

//        //    Leg res;
//        //    lock (_dbLock)
//        //    {
//        //        res = _data.Legs.FirstOrDefault(l => leg.NextLegs.HasFlag(l.CurrentLeg));

//        //    }
//        //    return res;
//        //}

//        public async Task SaveAsync()
//        {
//            try
//            {
//                //await _data.SaveChangesAsync();
//                lock (_dbLock)
//                {
//                    //_data.SaveChanges();
//                    _data.SaveChangesAsync();

//                }
//                Console.ForegroundColor = ConsoleColor.Blue;
//                Console.WriteLine($"***************************\nChanges are saved to the database\n***************************");
//                Console.ResetColor();
//            }
//            catch(Exception ex) 
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine($"***************************\n{ex.Message}\n***************************");
//                Console.ResetColor();
//            }
//        }
//        //public void Save()
//        //{
//        //    //_data.SaveChanges();

//        //    try
//        //    {
//        //        var res = _data.SaveChanges();
//        //        Console.ForegroundColor = ConsoleColor.Blue;
//        //        Console.WriteLine($"***************************\nNumber of saved changes: {res}\n***************************");
//        //        Console.ResetColor();
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        Console.ForegroundColor = ConsoleColor.Red;
//        //        Console.WriteLine($"***************************\n{ex.Message}\n***************************");
//        //        Console.ResetColor();
//        //    }
//        //}
//    }
//}
