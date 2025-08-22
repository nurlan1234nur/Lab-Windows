using System.Text.Json.Serialization;

namespace WorkerUI.Service
{
    public class LoginDtoAdmin
    {
        public string Email { get; set; } = "naran1@gmail.com";

        public string Password { get; set; } = "P@ssw0rd123";
    }
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
