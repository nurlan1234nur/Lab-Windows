using FlightSystem.Models;

namespace FlightSystem.Services
{
    public interface IFlightService
    {
        Task<IEnumerable<Flight>> GetFlightsAsync();
        Task<Flight?> GetFlightByIdAsync(string id);
        Task<(bool IsSuccess, string Message, int StatusCode, string? FlightId, Flight? Data)> CreateFlightAsync(CreateFlightDto dto, string uId);
        Task<(bool IsSuccess, string Message, int StatusCode)> UpdateFlightAsync(CreateFlightDto createFlightDto, string uId);
        Task<(bool IsSuccess, string Message, int StatusCode)> DeleteFlightAsync(string id);
        Task<List<Flight>> SearchFlightsAsync(string origin, string destination, DateTime date);
        Task<IEnumerable<Flight>> SearchFlightsAsync(string keyword);

    }
}
