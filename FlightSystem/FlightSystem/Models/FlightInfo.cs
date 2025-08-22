
namespace FlightSystem.Models
{
    public class FlightInfo
    {
        public string FlightInfoId { get; set; } = Guid.NewGuid().ToString(); // PK
        public string FlightId { get; set; } = string.Empty; // FK -> Flight
        public string Status { get; set; } = "Scheduled"; // Scheduled, Delayed, Cancelled
        public int AvailableSeats { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
