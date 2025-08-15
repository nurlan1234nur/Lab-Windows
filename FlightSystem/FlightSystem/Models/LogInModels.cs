using System.ComponentModel.DataAnnotations;
namespace FlightSystem.Models
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Имэйл заавал оруулах шаардлагатай.")]
        [EmailAddress(ErrorMessage = "Зөв имэйл хаяг оруулна уу.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Нууц үг заавал оруулах шаардлагатай.")]
        public string Password { get; set; } = string.Empty;
    }
    public class LoginResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string? Token { get; set; } // JWT token нэмэх боломжтой
    }
}
