namespace FlightSystem.Models
{

    public class Order
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();   // PK
        public string CustomerId { get; set; } = string.Empty;       // FK → Users.UserId
        public string FlightId { get; set; } = string.Empty;         // FK → Flights.Id
        public int Quantity { get; set; } = 1;                       // Суудлын тоо
        public decimal UnitPrice { get; set; }                       // Flight-ийн үнэ
        public decimal TotalAmount { get; set; }                     // UnitPrice * Quantity
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public string PaymentStatus { get; set; } = "Pending";      // Pending, Paid, Cancelled
        public string BookingStatus { get; set; } = "Confirmed";    // Confirmed, Cancelled
    }
}
