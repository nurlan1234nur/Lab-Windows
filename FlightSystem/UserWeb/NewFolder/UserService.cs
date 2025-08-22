using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using FlightSystem.Models; // User энд байгаа гэж үзэв

namespace UserWeb.Components.Pages
{
    public class UserApiClient
    {
        private readonly HttpClient _http;

        public UserApiClient(HttpClient http)
        {
            _http = http;
            if (_http.BaseAddress == null)
                _http.BaseAddress = new Uri("http://10.30.29.133:5000/");
        }

        // 1️⃣ Бүх хэрэглэгчийг авах
        public async Task<List<User>> GetUsersAsync()
        {
            var result = await _http.GetFromJsonAsync<List<User>>("api/auth/user-list");
            return result ?? new List<User>();
        }

        // 2️⃣ ID-аар хэрэглэгч авах
        public async Task<User?> GetUserByIdAsync(string id)
        {
            return await _http.GetFromJsonAsync<User>($"api/auth/user-info/{id}");
        }

        // 3️⃣ Passport-аар хэрэглэгч авах
        public async Task<User?> GetUserByPassportAsync(string passportNumber)
        {
            return await _http.GetFromJsonAsync<User>($"api/auth/user-info-byPassport/{passportNumber}");
        }

        // 4️⃣ Хэрэглэгч үүсгэх
        public async Task<(bool IsSuccess, string Message, User? Data)> CreateUserAsync(User dto)
        {
            var response = await _http.PostAsJsonAsync("api/auth/user-add", dto);

            var message = await response.Content.ReadAsStringAsync();

            User? data = null;
            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadFromJsonAsync<User>();
            }

            return (response.IsSuccessStatusCode, message, data);
        }

        // 5️⃣ Хэрэглэгч шинэчлэх
        public async Task<(bool IsSuccess, string Message)> UpdateUserAsync(User user)
        {
            // API-д тааруулж DTO бэлдэнэ
            var userToUpdate = new
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role
            };

            var res = await _http.PutAsJsonAsync("api/auth/user-update", userToUpdate);

            var message = await res.Content.ReadAsStringAsync();
            return (res.IsSuccessStatusCode, message);
        }

        // 6️⃣ Хэрэглэгч устгах
        public async Task<(bool IsSuccess, string Message)> DeleteUserAsync(string id)
        {
            var res = await _http.DeleteAsync($"api/auth/user-delete/{id}");
            var message = await res.Content.ReadAsStringAsync();
            return (res.IsSuccessStatusCode, message);
        }
    }
}
