using FlightSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightSystem.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService _seatService;

        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        // 1️⃣ Нислэгийн бүх суудлыг авах
        [HttpGet("{flightId}")]
        public async Task<IActionResult> GetSeats(string flightId)
        {
            var seats = await _seatService.GetSeatsByFlightAsync(flightId);
            return Ok(seats);
        }

        // 2️⃣ Сул байгаа суудлуудыг авах
        [HttpGet("available/{flightId}")]
        public async Task<IActionResult> GetAvailableSeats(string flightId)
        {
            var seats = await _seatService.GetAvailableSeatsAsync(flightId);
            return Ok(seats);
        }

        // 3️⃣ Суудлыг ID-аар авах
        [HttpGet("detail/{seatId}")]
        public async Task<IActionResult> GetSeatById(string seatId)
        {
            var seat = await _seatService.GetSeatByIdAsync(seatId);
            if (seat == null) return NotFound("Seat not found");
            return Ok(seat);
        }

        // 4️⃣ Суудал захиалах
        [HttpPost("reserve/{seatId}")]
        public async Task<IActionResult> ReserveSeat(string seatId, [FromBody] string orderId)
        {
            var success = await _seatService.ReserveSeatAsync(seatId, orderId);
            if (!success) return BadRequest("Seat already reserved or not found");
            return Ok("Seat reserved successfully");
        }

        // 5️⃣ Захиалга цуцлах
        [HttpPut("cancel/{seatId}")]
        public async Task<IActionResult> CancelReservation(string seatId)
        {
            var success = await _seatService.CancelReservationAsync(seatId);
            if (!success) return BadRequest("Seat not reserved or not found");
            return Ok("Reservation cancelled successfully");
        }
    }
}
