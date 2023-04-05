namespace ConsoleSimulator.Models
{
    //DTO = Data Transfer Object
    public class FlightDto
    {
        public string? Code { get; set; }
        public bool IsDeparture { get; set; }
        public virtual PilotDto? Pilot { get; set; }
        public bool IsActive { get; set; }

        public FlightDto() => Code = Guid.NewGuid().ToString();
    }
}