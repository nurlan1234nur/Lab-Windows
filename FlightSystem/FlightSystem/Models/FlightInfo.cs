
namespace FlightSystem.Models
{
    public class FlightInfo
    {
        public string FlightInfoId { get; set; } = Guid.NewGuid().ToString(); // PK
        public string? FlightId { get; set; } // FK
        public string PilotName { get; set; } = string.Empty;
        public int TotalSeats { get; set; }
        public string PlaneModel { get; set; } = string.Empty;
    }
}
