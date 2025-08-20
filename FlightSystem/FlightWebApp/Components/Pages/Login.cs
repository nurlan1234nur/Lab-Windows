using System.Text.Json.Serialization;

namespace FlightWebApp.Components.Pages
{
    public class LoginDto
    {
        public string Email { get; set; } = "naran1@gmail.com";

        public string Password { get; set; } = "P@ssw0rd123";
    }
    //public class LoginResponse
    //{
    //    public string id { get; set; } = string.Empty;
    //    public string firstName { get; set; } = string.Empty;
    //    public string role { get; set; } = string.Empty;
    //    public string? message { get; set; } // JWT token нэмэх боломжтой
    //}
    public class LoginResponse
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [JsonPropertyName("role")]
        public string? Role { get; set; }
    }
}
