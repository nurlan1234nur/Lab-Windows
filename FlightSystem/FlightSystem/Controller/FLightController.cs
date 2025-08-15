using Microsoft.AspNetCore.Mvc;
using FlightSystem.Models;
using FlightSystem.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightApiWithSQLite.Controllers
{
    [ApiController]
    [Route("api/flight")]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _service;

        public FlightController(IFlightService service)
        {
            _service = service;
        }

        // Бүх нислэгийг авах
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Flight>>> GetFlights()
        {
            var flights = await _service.GetFlightsAsync();
            return Ok(flights);
        }

        // Нислэгийг ID-аар авах
        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetFlight(string id)
        {
            var flight = await _service.GetFlightByIdAsync(id);
            if (flight == null)
                return NotFound("Нислэг олдсонгүй.");
            return Ok(flight);
        }

        // Шинэ нислэг үүсгэх
        [HttpPost("add")]
        public async Task<ActionResult> CreateFlight([FromBody] CreateFlightDto dto, [FromHeader] string uId)
        {
            var result = await _service.CreateFlightAsync(dto, uId);
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.Message);

            var createdFlight = await _service.GetFlightByIdAsync(result.FlightId!);
            return CreatedAtAction(nameof(GetFlight), new { id = result.FlightId }, createdFlight);
        }

        // Нислэг update хийх
        [HttpPut("update")]
        public async Task<ActionResult> UpdateFlight([FromBody] CreateFlightDto createFlightDto, [FromHeader] string uId)
        {
            var result = await _service.UpdateFlightAsync(createFlightDto, uId);
            return StatusCode(result.StatusCode, result.Message);
        }

        // Нислэг устгах
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteFlight(string id)
        {
            var result = await _service.DeleteFlightAsync(id);
            return StatusCode(result.StatusCode, result.Message);
        }

        // Нислэг хайх
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Flight>>> SearchFlights([FromQuery] string keyword)
        {
            var flights = await _service.SearchFlightsAsync(keyword);
            return Ok(flights);
        }
    }
}
