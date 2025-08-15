using FlightSystem.Models;
using Microsoft.EntityFrameworkCore;
using ApiWithSQLite.Data;

namespace FlightSystem.Services
{
    public class FlightService(AppDbContext context) : IFlightService
    {
        private readonly AppDbContext _context = context;

        // Бүх нислэгийг авах
        public async Task<IEnumerable<Flight>> GetFlightsAsync() =>
            await _context.Flights.ToListAsync();

        // Нислэгийг ID-аар авах
        public async Task<Flight?> GetFlightByIdAsync(string id) =>
            await _context.Flights.FindAsync(id);

        // Шинэ нислэг үүсгэх
        public async Task<(bool IsSuccess, string Message, int StatusCode, string? FlightId, Flight? Data)> CreateFlightAsync(CreateFlightDto dto, string uId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == uId);
            if (user is null) return (false, "Хэрэглэгч олдсонгүй.", 401, null, null);
            if (user.Role.Trim().ToLower() != "admin") return (false, "Админ эрх шаардлагатай.", 403, null, null);

            // FlightNumber үүсгэх
            string prefix = dto.Destination.Length >= 3 ? dto.Destination[..3].ToUpper() : "XXX";
            var lastFlight = await _context.Flights
                .Where(f => (f.FlightNumber ?? string.Empty).StartsWith(prefix))
                .OrderByDescending(f => f.FlightNumber)
                .FirstOrDefaultAsync();

            int nextNumber = 1;
            if (lastFlight != null && lastFlight.FlightNumber.Length >= 6 &&
                int.TryParse(lastFlight.FlightNumber[3..], out var parsed))
                nextNumber = parsed + 1;

            var flightId = Guid.NewGuid().ToString();
            var flightNumber = prefix + nextNumber.ToString("D3");

            // Flight объект үүсгэх
            var flight = new Flight
            {
                FlightId = flightId,
                FlightNumber = flightNumber,
                Origin = dto.Origin,
                Destination = dto.Destination,
                DepartureTime = dto.DepartureTime,
                ArrivalTime = dto.ArrivalTime,
                Price = dto.Price,
                Airline = dto.Airline,
                Status = dto.Status
            };

            // FlightInfo объект үүсгэх
            var flightInfo = new FlightInfo
            {
                FlightId = flightId,
                PilotName = dto.PilotName,
                TotalSeats = dto.TotalSeats,
                AvailableSeats = dto.AvailableSeats,
                PlaneModel = dto.PlaneModel
            };

            _context.Flights.Add(flight);
            _context.FlightInfos.Add(flightInfo);
            await _context.SaveChangesAsync();

            return (true, "Нислэг амжилттай нэмэгдлээ.", 201, flightId, flight);
        }

        // Нислэгийг шинэчлэх
        public async Task<(bool IsSuccess, string Message, int StatusCode)> UpdateFlightAsync(CreateFlightDto dto, string uId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == uId);
            if (user is null) return (false, "Хэрэглэгч олдсонгүй.", 401);
            if (user.Role.Trim().ToLower() != "admin") return (false, "Зөвхөн админ өөрчилнө.", 403);

            var existingFlight = await _context.Flights.FindAsync(dto.FlightId);
            if (existingFlight is null) return (false, "Нислэг олдсонгүй.", 400);

            var existingFlightInfo = await _context.FlightInfos.FindAsync(dto.FlightId);
            if (existingFlightInfo is null) return (false, "Нислэгийн нэмэлт мэдээлэл олдсонгүй.", 400);

            // Flight талбаруудыг шинэчлэх
            existingFlight.Origin = dto.Origin;
            existingFlight.Destination = dto.Destination;
            existingFlight.DepartureTime = dto.DepartureTime;
            existingFlight.ArrivalTime = dto.ArrivalTime;
            existingFlight.Price = dto.Price;
            existingFlight.Airline = dto.Airline;
            existingFlight.Status = dto.Status;

            // FlightInfo талбаруудыг шинэчлэх
            existingFlightInfo.PilotName = dto.PilotName;
            existingFlightInfo.TotalSeats = dto.TotalSeats;
            existingFlightInfo.AvailableSeats = dto.AvailableSeats;
            existingFlightInfo.PlaneModel = dto.PlaneModel;

            await _context.SaveChangesAsync();
            return (true, "Амжилттай шинэчлэгдлээ.", 200);
        }

        // Нислэг устгах
        public async Task<(bool IsSuccess, string Message, int StatusCode)> DeleteFlightAsync(string id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight is null) return (false, "Нислэг олдсонгүй.", 400);

            var flightInfo = await _context.FlightInfos.FindAsync(id);

            _context.Flights.Remove(flight);
            if (flightInfo != null)
                _context.FlightInfos.Remove(flightInfo);

            await _context.SaveChangesAsync();
            return (true, "Нислэг устгагдлаа.", 200);
        }

        // Нислэг хайх
        public async Task<IEnumerable<Flight>> SearchFlightsAsync(string keyword)
        {
            var allFlights = await _context.Flights.ToListAsync();
            return allFlights
                .Where(f =>
                    (!string.IsNullOrEmpty(f.FlightNumber) && f.FlightNumber.Contains(keyword, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrEmpty(f.Origin) && f.Origin.Contains(keyword, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrEmpty(f.Destination) && f.Destination.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }
    }
}
