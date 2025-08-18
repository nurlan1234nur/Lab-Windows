namespace FlightWebApp.Components.Pages
{
    public class FlightDto
    {
        public string? FlightId { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public string? FlightNumber { get; set; }

        public string? PilotName { get; set; }
        public int FlightAllSeat { get; set; }
        public double Price { get; set; }
        public string? Status { get; set; }
        public string? Type { get; set; }
    }
}
