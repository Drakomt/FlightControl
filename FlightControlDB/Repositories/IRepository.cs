using FlightControlDB.Models;

namespace FlightControlDB.Repositories
{
    public interface IRepository
    {
        Task AddFlightAsync(Flight flight);
        Task AddLoggerAsync(Logger logger);
        Task<Leg> FirstLegAsync();
        Task<List<Logger>> LoggerListAsync();
        Task<List<Leg>> NextLegsAsync(Leg leg);
        Task<Logger> GetLogAsync(DateTime dateIn, int flightId);
        Task<List<Leg>> GetLegsAsync();
        Task SaveAsync();
        //void Save();

    }
}
