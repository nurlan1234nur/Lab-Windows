namespace FlightWebApp.Components.Pages
{
    public class FlightInfoDto
    {
        public string? FlightId { get; set; }
        public string? FlightNumber { get; set; }
        public string? PilotName { get; set; }
        public int FlightAllSeat { get; set; }
        public int FlightAvailableSeat { get; set; }
        public double Price { get; set; }
        public string? Status { get; set; }
        public string? Type { get; set; }
    }
}