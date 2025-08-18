using FlightSystem.Models;
using ApiWithSQLite.Data;
using Microsoft.EntityFrameworkCore;

namespace FlightSystem.Services
{
    public class FlightInfoService(AppDbContext context) : IFlightInfoService
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<FlightInfo>> GetFlightInfoListAsync() =>
            await _context.FlightInfos.ToListAsync();

        public async Task<FlightInfo?> GetFlightInfoByIdAsync(string id) =>
            await _context.FlightInfos.FirstOrDefaultAsync(f => f.FlightId == id);

        public async Task<(string Message, int StatusCode)> UpdateFlightInfoAsync(FlightInfo flightInfo)
        {
            var existing = await _context.FlightInfos
                .FirstOrDefaultAsync(f => f.FlightInfoId == flightInfo.FlightInfoId);

            if (existing == null)
                return ("Нислэгийн мэдээлэл олдсонгүй.", 400);

            existing.PilotName = flightInfo.PilotName;
            existing.TotalSeats = flightInfo.TotalSeats;
            existing.PlaneModel = flightInfo.PlaneModel;

            await _context.SaveChangesAsync();
            return ("Амжилттай шинэчлэгдлээ.", 200);
        }
    }
}
