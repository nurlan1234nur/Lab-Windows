namespace FlightSystem.Models
{
    public class Seat
    {
        public string SeatId { get; set; } = Guid.NewGuid().ToString();
        public string? FlightId { get; set; } 
        public string SeatNumber { get; set; } = string.Empty;
        public bool IsReserved { get; set; } = false;
        public string? OrderId { get; set; }
    }
}
