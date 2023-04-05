namespace FlightControlDB.Models
{
    [Flags]
    public enum LegNumber
    {
        One = 0b0000000001,   //1
        Two = 0b0000000010,   //2
        Three = 0b0000000100,   //4
        Four = 0b0000001000,   //8
        Five = 0b0000010000,    //16
        Six = 0b0000100000,     //32
        Seven = 0b0001000000,   //64
        Eight = 0b0010000000,    //128
        Departure = 0b0100000000,   //256
        ForDeparture = 0b1000000000,  //512
    }
}
