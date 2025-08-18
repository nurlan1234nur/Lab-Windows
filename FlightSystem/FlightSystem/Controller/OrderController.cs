using Microsoft.AspNetCore.Mvc;
using FlightSystem.Models;
using FlightSystem.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightApiWithSQLite.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // Бүх захиалгын жагсаалт
        [HttpGet("order-list")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _orderService.GetOrdersAsync();
            return Ok(orders);
        }

        // Нэг захиалга авах
        [HttpGet("order-info/{id}")]
        public async Task<ActionResult<Order>> GetOrder(string id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null) return NotFound("Захиалга олдсонгүй.");
            return Ok(order);
        }

        // Шинэ захиалга үүсгэх
        [HttpPost("order-add")]
        public async Task<ActionResult> CreateOrder([FromBody] Order order, [FromHeader] string uId)
        {
            // Клиентээс ирсэн утгыг зөвшөөрөх талбарууд:
            // customerId, flightId, quantity, unitPrice
            if (string.IsNullOrWhiteSpace(order.CustomerId))
                return BadRequest("CustomerId is required.");

            if (string.IsNullOrWhiteSpace(order.FlightId))
                return BadRequest("FlightId is required.");

            if (order.Quantity <= 0)
                order.Quantity = 1; // default

            // Сервер талд шаардлагатай талбаруудыг үүсгэх
            order.Id = Guid.NewGuid().ToString();
            order.TotalAmount = order.UnitPrice * order.Quantity;
            order.OrderDate = DateTime.UtcNow;
            order.PaymentStatus = "Pending";
            order.BookingStatus = "Confirmed";

            var result = await _orderService.CreateOrderAsync(order, uId);

            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.Message);

            var createdOrder = await _orderService.GetOrderByIdAsync(result.OrderId!);
            return CreatedAtAction(nameof(GetOrder), new { id = result.OrderId }, createdOrder);
        }



        // Захиалга update хийх
        [HttpPost("order-update")]
        public async Task<ActionResult> UpdateOrder([FromBody] Order order, [FromHeader] string uId)
        {
            var result = await _orderService.UpdateOrderAsync(order, uId);
            return StatusCode(result.StatusCode, result.Message);
        }

        // Захиалга устгах
        [HttpDelete("order-delete/{id}")]
        public async Task<ActionResult> DeleteOrder(string id)
        {
            var result = await _orderService.DeleteOrderAsync(id);
            return StatusCode(result.StatusCode, result.Message);
        }

        // Хэрэглэгчийн бүх захиалга авах
        [HttpGet("customer-orders/{customerId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByCustomer(string customerId)
        {
            var orders = await _orderService.GetOrdersByCustomerIdAsync(customerId);
            return Ok(orders);
        }
    }
}
