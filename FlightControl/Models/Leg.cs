using System.Security.Cryptography;

namespace FlightControl.Models
{
    public class Leg
    {
        public int Id { get; set; }
        //public int Number { get; set; }
        public int WaitTime { get; set; }
        //public virtual Flight? Flight { get; set; }
        public bool IsEmpty { get; set; }
        public LegNumber CurrentLeg { get; set; }
        public LegNumber NextLegs { get; set; }
        public bool IsChangeStatus { get; set; }
    }
}
