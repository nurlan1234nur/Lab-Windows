using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using FlightSystem.Models; // Seat model энд байгаа гэж үзье

namespace WorkerUI.Service
{
    public class SeatApiClient
    {
        private readonly HttpClient _http;

        public SeatApiClient(HttpClient http)
        {
            _http = http;
            if (_http.BaseAddress == null)
                _http.BaseAddress = new Uri("http://10.30.29.133:5000/");
        }

        // 1️⃣ Нислэгийн бүх суудлыг авах
        public async Task<List<Seat>> GetSeatsByFlightAsync(string flightId)
        {
            var result = await _http.GetFromJsonAsync<List<Seat>>(
                $"api/seat/{flightId}");
            return result ?? new List<Seat>();
        }

        // 2️⃣ Сул байгаа суудлуудыг авах
        public async Task<List<Seat>> GetAvailableSeatsAsync(string flightId)
        {
            var result = await _http.GetFromJsonAsync<List<Seat>>(
                $"api/seat/available/{flightId}");
            return result ?? new List<Seat>();
        }

        // 3️⃣ Суудал захиалах
        public async Task<(bool IsSuccess, string Message)> ReserveSeatAsync(string seatId, string orderId)
        {
            var res = await _http.PostAsJsonAsync(
                $"api/seat/reserve/{seatId}", orderId);

            var message = await res.Content.ReadAsStringAsync();
            return (res.IsSuccessStatusCode, message);
        }

        // 4️⃣ Захиалга цуцлах
        public async Task<(bool IsSuccess, string Message)> CancelSeatAsync(string seatId)
        {
            var res = await _http.PutAsync(
                $"api/seat/cancel/{seatId}", null);

            var message = await res.Content.ReadAsStringAsync();
            return (res.IsSuccessStatusCode, message);
        }
    }
}
