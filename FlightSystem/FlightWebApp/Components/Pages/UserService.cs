using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using FlightSystem.Models; // UserDto, CreateUserDto энд байна гэж үзэв

namespace FlightWebApp.Components.Pages
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
            var result = await _http.GetFromJsonAsync<List<User>>(
                "http://10.30.29.133:5000/api/auth/user-list");
            return result ?? new List<User>();
        }

        // 2️⃣ ID-аар хэрэглэгч авах
        public async Task<User?> GetUserByIdAsync(string id)
        {
            return await _http.GetFromJsonAsync<User>(
                "api/auth/user-info/{id}");
        }

        // 3️⃣ Хэрэглэгч үүсгэх
        public async Task<(bool IsSuccess, string Message, User? Data)> CreateUserAsync(User dto)
        {
            var response = await _http.PostAsJsonAsync(
                "http://10.30.29.133:5000/api/auth/user-add", dto);

            var message = await response.Content.ReadAsStringAsync();

            User? data = null;
            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadFromJsonAsync<User>();
            }

            return (response.IsSuccessStatusCode, message, data);
        }

        // 4️⃣ Хэрэглэгч шинэчлэх
        public async Task<(bool IsSuccess, string Message)> UpdateUserAsync(User user)
        {
            // UserDto-г User болгож хувиргаж дамжуулж байна
            var userToUpdate = new
            {
                Id = user.Id,
                Name = user.FirstName,
                Email = user.Email,
                Role = user.Role
            };

            var res = await _http.PostAsJsonAsync(
                "api/auth/user-update", userToUpdate);

            var message = await res.Content.ReadAsStringAsync();
            return (res.IsSuccessStatusCode, message);
        }

        // 5️⃣ Хэрэглэгч устгах
        public async Task<(bool IsSuccess, string Message)> DeleteUserAsync(string id)
        {
            var res = await _http.DeleteAsync(
                "api/auth/user-delete/{id}");
            var message = await res.Content.ReadAsStringAsync();
            return (res.IsSuccessStatusCode, message);
        }
    }
}
