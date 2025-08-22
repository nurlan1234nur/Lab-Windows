using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using FlightSystem.Models; // FlightInfoDto энд байгаа гэж үзнэ

namespace WorkerUI.Service
{
    public class FlightInfoApiClient
    {
        private readonly HttpClient _http;

        public FlightInfoApiClient(HttpClient http)
        {
            _http = http;
            if (_http.BaseAddress == null)
                _http.BaseAddress = new Uri("http://10.30.29.133:5000/");
        }

        // FlightInfo жагсаалт авах
        public async Task<List<FlightInfo>> GetFlightInfosAsync()
        {
            var result = await _http.GetFromJsonAsync<List<FlightInfo>>($"api/flight-info/flight-info-list");
            return result ?? new List<FlightInfo>();
        }

        // FlightInfo-г FlightId-аар авах
        public async Task<FlightInfo?> GetFlightInfoByFlightIdAsync(string flightId)
        {
            return await _http.GetFromJsonAsync<FlightInfo>($"api/flight-info/flight-info/{flightId}");
        }

        // FlightInfo-г шинэчлэх
        public async Task<(bool IsSuccess, string Message)> UpdateFlightInfoAsync(FlightInfo dto)
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
