using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using FlightSystem.Models; // FlightInfoDto энд байгаа гэж үзнэ

namespace FlightWebApp.Components.Pages
{
    public class FlightInfoApiClient
    {
        private readonly HttpClient _http;

        public FlightInfoApiClient(HttpClient http)
        {
            _http = http;
            if (_http.BaseAddress == null)
                _http.BaseAddress = new Uri("http://192.168.216.1:5000/");
        }

        // FlightInfo жагсаалт авах
        public async Task<List<FlightInfoDto>> GetFlightInfosAsync()
        {
            var result = await _http.GetFromJsonAsync<List<FlightInfoDto>>("api/flight-info/flight-info-list");
            return result ?? new List<FlightInfoDto>();
        }

        // FlightInfo-г FlightId-аар авах
        public async Task<FlightInfoDto?> GetFlightInfoByFlightIdAsync(string flightId)
        {
            return await _http.GetFromJsonAsync<FlightInfoDto>($"api/flight-info/flight-info/{flightId}");
        }

        // FlightInfo-г шинэчлэх
        public async Task<(bool IsSuccess, string Message)> UpdateFlightInfoAsync(FlightInfoDto dto)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/flight-info/flight-info-update")
            {
                Content = JsonContent.Create(dto)
            };

            var res = await _http.SendAsync(request);
            var message = await res.Content.ReadAsStringAsync();
            return (res.IsSuccessStatusCode, message);
        }
    }
}
