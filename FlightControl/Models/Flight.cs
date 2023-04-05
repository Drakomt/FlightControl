using System.ComponentModel.DataAnnotations;

namespace FlightControl.Models
{
    public class Flight
    {
        public int Id { get; set; }
        [Required]
        public string? Code { get; set; }
        public bool IsDeparture { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public virtual Pilot? Pilot { get; set; }
    }
}
