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
        }

        // 1️⃣ Бүх хэрэглэгчийг авах
        public async Task<List<CreateFlightDto>> GetUsersAsync()
        {
            var result = await _http.GetFromJsonAsync<List<CreateFlightDto>>(
                "http://192.168.216.1:5000/api/auth/user-list");
            return result ?? new List<CreateFlightDto>();
        }

        // 2️⃣ ID-аар хэрэглэгч авах
        public async Task<CreateFlightDto?> GetUserByIdAsync(string id)
        {
            return await _http.GetFromJsonAsync<CreateFlightDto>(
                $"http://192.168.216.1:5000/api/auth/user-info/{id}");
        }

        // 3️⃣ Хэрэглэгч үүсгэх
        public async Task<(bool IsSuccess, string Message, CreateFlightDto? Data)> CreateUserAsync(CreateUserDto dto)
        {
            var response = await _http.PostAsJsonAsync(
                "http://192.168.216.1:5000/api/auth/user-add", dto);

            var message = await response.Content.ReadAsStringAsync();

            CreateFlightDto? data = null;
            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadFromJsonAsync<CreateFlightDto>();
            }

            return (response.IsSuccessStatusCode, message, data);
        }

        // 4️⃣ Хэрэглэгч шинэчлэх
        public async Task<(bool IsSuccess, string Message)> UpdateUserAsync(CreateFlightDto user)
        {
            // UserDto-г User болгож хувиргаж дамжуулж байна
            var userToUpdate = new
            {
                Id = user.FlightId,
                Name = user.,
                Email = user.Email,
                Role = user.Role
            };

            var res = await _http.PostAsJsonAsync(
                "http://192.168.216.1:5000/api/auth/user-update", userToUpdate);

            var message = await res.Content.ReadAsStringAsync();
            return (res.IsSuccessStatusCode, message);
        }

        // 5️⃣ Хэрэглэгч устгах
        public async Task<(bool IsSuccess, string Message)> DeleteUserAsync(string id)
        {
            var res = await _http.DeleteAsync(
                $"http://192.168.216.1:5000/api/auth/user-delete/{id}");
            var message = await res.Content.ReadAsStringAsync();
            return (res.IsSuccessStatusCode, message);
        }
    }
}
