namespace FlightWebApp.Components.Pages
{
    public class LoginDto
    {
        public string Email { get; set; } = string.Empty;

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
