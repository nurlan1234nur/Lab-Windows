using FlightSystem.Models;
using Microsoft.EntityFrameworkCore;
using ApiWithSQLite.Data;

namespace FlightSystem.Services
{
    public class OrderService(AppDbContext context) : IOrderService
    {
        private readonly AppDbContext _context = context;

        // Бүх захиалгыг авах
        public async Task<IEnumerable<Order>> GetOrdersAsync() =>
            await _context.Orders.ToListAsync();

        // ID-аар захиалга авах
        public async Task<Order?> GetOrderByIdAsync(string id) =>
            await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);

        // Шинэ захиалга үүсгэх
        public async Task<(bool IsSuccess, string Message, int StatusCode, string? OrderId, Order? Data)> CreateOrderAsync(Order order, string uId)
        {
            // Хэрэглэгчийн эрх шалгах
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == uId);
            if (user is null) return (false, "Хэрэглэгч олдсонгүй.", 401, null, null);

            order.Id = Guid.NewGuid().ToString();
            order.OrderDate = DateTime.UtcNow;

            // Жижиг систем учраас зөвхөн нэг Flight-ийн үнэ ашиглана
            var flight = await _context.Flights.FindAsync(order.FlightId);
            if (flight == null) return (false, $"Flight {order.FlightId} олдсонгүй.", 404, null, null);

            order.UnitPrice = flight.Price;
            order.TotalAmount = flight.Price * order.Quantity;

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return (true, "Захиалга амжилттай үүслээ.", 201, order.Id, order);
        }

        // Захиалга update хийх
        public async Task<(bool IsSuccess, string Message, int StatusCode)> UpdateOrderAsync(Order order, string uId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == uId);
            if (user is null) return (false, "Хэрэглэгч олдсонгүй.", 401);

            var existingOrder = await _context.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);
            if (existingOrder == null) return (false, "Захиалга олдсонгүй.", 404);

            existingOrder.BookingStatus = order.BookingStatus;
            existingOrder.PaymentStatus = order.PaymentStatus;

            // Flight үнээр нийт дүнг шинэчлэх
            var flight = await _context.Flights.FindAsync(order.FlightId);
            if (flight == null) return (false, $"Flight {order.FlightId} олдсонгүй.", 404);

            existingOrder.FlightId = order.FlightId;
            existingOrder.UnitPrice = flight.Price;
            existingOrder.Quantity = order.Quantity;
            existingOrder.TotalAmount = flight.Price * order.Quantity;

            await _context.SaveChangesAsync();
            return (true, "Захиалга амжилттай шинэчлэгдлээ.", 200);
        }

        // Захиалга устгах
        public async Task<(bool IsSuccess, string Message, int StatusCode)> DeleteOrderAsync(string id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (order == null) return (false, "Захиалга олдсонгүй.", 404);

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return (true, "Захиалга устгагдлаа.", 200);
        }

        // Хэрэглэгчийн бүх захиалга авах
        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(string customerId) =>
            await _context.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
    }
}
