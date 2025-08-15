using Microsoft.AspNetCore.Mvc;
using FlightSystem.Services;
using FlightSystem.Models;

namespace FlightSystem.Controller
{
    [ApiController]
    [Route("api/flight-info")]
    public class FlightInfoController : ControllerBase
    {
        private readonly IFlightInfoService _service;

        public FlightInfoController(IFlightInfoService service)
        {
            _service = service;
        }

        [HttpGet("flight-info-list")]
        public async Task<ActionResult<IEnumerable<FlightInfo>>> GetFlightInfoList()
        {
            var result = await _service.GetFlightInfoListAsync();
            return Ok(result);
        }

        [HttpGet("flight-info/{id}")]
        public async Task<ActionResult<FlightInfo>> GetFlightInfo(string id)
        {
            var flightInfo = await _service.GetFlightInfoByIdAsync(id);
            if (flightInfo == null)
            {
                return NotFound("Нислэг олдсонгүй.");
            }
            return Ok(flightInfo);
        }

        [HttpPost("flight-info-update")]
        public async Task<ActionResult> UpdateFlightInfo([FromBody] FlightInfo flightInfo)
        {
            var result = await _service.UpdateFlightInfoAsync(flightInfo);
            return StatusCode(result.StatusCode, result.Message);
        }
    }
}
