
namespace FlightSystem.Models
{
    public class CreateFlightDto
    {
        public string? FlightId { get; set; }
        public string FlightNumber { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public DateTime ScheduledDeparture { get; set; }
        public DateTime ScheduledArrival { get; set; }
        public string Airline { get; set; } = string.Empty;
        public int TotalSeats { get; set; }
        public decimal Price { get; set; }

        public string? FlightInfoId { get; set; }
        public string Status { get; set; } = "Scheduled"; // Scheduled, Delayed, Cancelled
        public int AvailableSeats { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
