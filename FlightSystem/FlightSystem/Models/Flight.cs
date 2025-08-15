namespace FlightSystem.Models
{

    public class Flight
    {
        public string FlightId { get; set; } = Guid.NewGuid().ToString(); // PK
        public string FlightNumber { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; } // нэг суудлын үнэ
        public string Airline { get; set; } = string.Empty; // Жишээ нь: MIAT, Delta, гэх мэт
        public string Status { get; set; } = "Scheduled"; // Scheduled, Cancelled, Delayed
    }
}

