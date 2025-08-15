namespace FlightWebApp.Components.Pages
{
    public class Order
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? CustomerId { get; set; }
        public string? FlightId { get; set; }
        public double Price { get; set; }
    }
}

