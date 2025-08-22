using System.Net.Http.Json;
using FlightSystem.Models;

namespace UserWeb.Components.Pages
{
    public class OrderApiClient
    {
        private readonly HttpClient _http;

        public OrderApiClient(HttpClient http)
        {
            _http = http;

            // BaseAddress-ийг нэг удаа тохируулна
            if (_http.BaseAddress == null)
            {
                _http.BaseAddress = new Uri("http://10.30.29.133:5000/");
            }
        }

        // Бүх захиалгууд
        public async Task<List<Order>> GetOrdersAsync()
        {
            var result = await _http.GetFromJsonAsync<List<Order>>("api/order/order-list");
            return result ?? new List<Order>();
        }

        // ID-р захиалга авах
        public async Task<Order?> GetOrderByIdAsync(string id)
        {
            return await _http.GetFromJsonAsync<Order>($"api/order/order-info/{id}");
        }

        // Захиалга үүсгэх
        public async Task<string> CreateOrderAsync(Order order)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"api/order/order-add")
            {
                Content = JsonContent.Create(order)
            };
            //request.Headers.Add("uId", uId);

            var res = await _http.SendAsync(request);
            return await res.Content.ReadAsStringAsync();
        }

        // Захиалга шинэчлэх
        public async Task<string> UpdateOrderAsync(Order order, string uId)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"api/order/order-update")
            {
                Content = JsonContent.Create(order)
            };
            request.Headers.Add("uId", uId);

            var res = await _http.SendAsync(request);
            return await res.Content.ReadAsStringAsync();
        }

        // Захиалга устгах
        public async Task<string> DeleteOrderAsync(string id)
        {
            var res = await _http.DeleteAsync($"api/order/order-delete/{id}");
            return await res.Content.ReadAsStringAsync();
        }

        // Хэрэглэгчийн бүх захиалга авах
        public async Task<List<Order>> GetOrdersByCustomerIdAsync(string customerPassport)
        {
            Console.WriteLine(customerPassport + $"api/order/customer-orders/{customerPassport}");
            var result = await _http.GetFromJsonAsync<List<Order>>($"api/order/customer-orders/{customerPassport}");
            return result ?? new List<Order>();
        }
    }
}
