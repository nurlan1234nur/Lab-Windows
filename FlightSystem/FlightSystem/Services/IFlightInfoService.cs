using FlightSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightSystem.Services
{
    public interface IFlightInfoService
    {
        Task<IEnumerable<FlightInfo>> GetFlightInfoListAsync();
        Task<FlightInfo?> GetFlightInfoByIdAsync(string id);
        Task<(string Message, int StatusCode)> UpdateFlightInfoAsync(FlightInfo flightInfo);
    }
}
