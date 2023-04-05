namespace FlightControl.Models
{
    [Flags]
    public enum LegNumber
    {
        One = 0b000000001,   //1
        Two = 0b000000010,   //2
        Thr = 0b000000100,   //4
        Fou = 0b000001000,   //8
        Fiv = 0b000010000,
        Six = 0b000100000,
        Sev = 0b001000000,
        Eig = 0b010000000,
        Dep = 0b100000000,
    }
}
