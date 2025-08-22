namespace FlightSystem.Models
{

    public class Flight
    {
        public string FlightId { get; set; } = Guid.NewGuid().ToString(); // PK
        public string FlightNumber { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public DateTime ScheduledDeparture { get; set; }
        public DateTime ScheduledArrival { get; set; }
        public string Airline { get; set; } = string.Empty;
        public int TotalSeats { get; set; }
        public decimal Price { get; set; }
    }
}

