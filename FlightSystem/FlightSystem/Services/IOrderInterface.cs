using FlightSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightSystem.Services
{
    public interface IOrderService
    {
        // Бүх захиалгыг авах (OrderItems-ийг дагалдуулна)
        Task<IEnumerable<Order>> GetOrdersAsync();

        // ID-аар нэг захиалга авах (OrderItems-ийг дагалдуулна)
        Task<Order?> GetOrderByIdAsync(string id);

        // Захиалга үүсгэх (Order + OrderItems)
        Task<(bool IsSuccess, string Message, int StatusCode, string? OrderId, Order? Data)> CreateOrderAsync(Order order, string uId);

        // Захиалга update хийх (Order + OrderItems)
        Task<(bool IsSuccess, string Message, int StatusCode)> UpdateOrderAsync(Order order, string uId);

        // Захиалга устгах (Order + OrderItems)
        Task<(bool IsSuccess, string Message, int StatusCode)> DeleteOrderAsync(string id);

        // Customer ID-аар захиалгуудыг авах (OrderItems-ийг дагалдуулна)
        Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(string customerId);
    }
}
