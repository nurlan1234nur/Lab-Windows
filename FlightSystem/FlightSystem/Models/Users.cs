namespace FlightSystem.Models
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString(); // PK

        // Хувийн мэдээлэл
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string PassportNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        // Нэвтрэх/эрхийн мэдээлэл
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "Customer"; // Admin, Staff, Customer

        // Системийн мөрдөлт
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }


}