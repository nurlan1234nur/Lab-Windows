using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using FlightWebApp.Components.Pages;
using FlightSystem.Models;

namespace FlightWebApp.Components.Pages
{
    public class FlightApiClient
    {
        private readonly HttpClient _http;

        public FlightApiClient(HttpClient http)
        {
            _http = http;
            if (_http.BaseAddress == null)
                _http.BaseAddress = new Uri("http://10.30.29.133:5000/");
        }

        // Бүх нислэгүүдийг авах
        public async Task<List<FlightDto>> GetFlightsAsync()
        {
            var result = await _http.GetFromJsonAsync<List<FlightDto>>($"api/flight/flight-list");
            return result ?? new List<FlightDto>();
        }

        // ID-аар нислэг авах
        public async Task<FlightDto?> GetFlightByIdAsync(string id)
        {
            return await _http.GetFromJsonAsync<FlightDto>($"api/flight/flight/{id}");
        }

        // Нислэг нэмэх
        public async Task<(bool IsSuccess, string Message)> CreateFlightAsync(CreateFlightDto dto, string userId)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"api/flight/flight-add")
            {
                Content = JsonContent.Create(dto)
            };
            request.Headers.Add("uId", userId);

            var response = await _http.SendAsync(request);
            var message = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, message);
        }

        // Нислэг шинэчлэх
        public async Task<(bool IsSuccess, string Message)> UpdateFlightAsync(CreateFlightDto dto, string userId)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"api/flight/flight-update")
            {
                Content = JsonContent.Create(dto)
            };
            request.Headers.Add("uId", userId);

            var response = await _http.SendAsync(request);
            var message = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, message);
        }

        // Нислэг устгах
        public async Task<(bool IsSuccess, string Message)> DeleteFlightAsync(string id)
        {
            var response = await _http.DeleteAsync($"api/flight/flight-delete/{id}");
            var message = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, message);
        }

        // Нислэг хайх
        public async Task<List<FlightDto>> SearchFlightsAsync(string query)
        {
            var result = await _http.GetFromJsonAsync<List<FlightDto>>($"api/flight/search?query={query}");
            return result ?? new List<FlightDto>();
        }
    }
}
