using ConsoleSimulator.Models;
using RandomFriendlyNameGenerator;
using System.Net.Http.Json;

namespace ConsoleSimulator
{
    internal class Program
    {
        //private static int _planesInRunway = 0;
        public static void Main(string[] args)
        {
            HttpClient client = new() { BaseAddress = new Uri("http://localhost:5132") };


            System.Timers.Timer timer = new System.Timers.Timer(10000);
            timer.Elapsed += (s, e) => CreateFlight();
            timer.Start();

            Console.ReadLine();

            async Task CreateFlight()
            {
                //if (_planesInRunway <= 4)
                //{
                //    _planesInRunway++;
                var flight = new FlightDto { IsDeparture = false, IsActive = true, Pilot = new PilotDto { Name = NameGenerator.PersonNames.Get() } };
                await Console.Out.WriteLineAsync($"Flight number: {flight.Code}, Pilot Name: {flight.Pilot.Name}");
                //Console.WriteLine($"Flight number: {flight.Code}, Pilot Name: {flight.Pilot.Name}");
                var response = await client.PostAsJsonAsync("api/Flights", flight);
                //if (response.IsSuccessStatusCode)
                //{
                //    await Console.Out.WriteLineAsync($"Flight number: {flight.Code}, Pilot Name: {flight.Pilot.Name}");
                //}
                //}
            }
        }
    }
}
