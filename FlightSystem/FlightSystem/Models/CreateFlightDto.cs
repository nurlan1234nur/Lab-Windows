
namespace FlightSystem.Models
{
    public class CreateFlightDto
    {
        public string? FlightId { get; set; } 
        public string FlightNumber { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; } // нэг суудлын үнэ
        public string Airline { get; set; } = string.Empty; // Жишээ нь: MIAT, Delta, гэх мэт
        public string Status { get; set; } = "Scheduled"; // Scheduled, Cancelled, Delayed

        public string? FlightInfoId { get; set; } 
        public string PilotName { get; set; } = string.Empty;
        public int TotalSeats { get; set; }
        public string PlaneModel { get; set; } = string.Empty;
    }
}
