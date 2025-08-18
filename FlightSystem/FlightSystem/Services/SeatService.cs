using ApiWithSQLite.Data;
using FlightSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightSystem.Services
{
    public class SeatService : ISeatService
    {
        private readonly AppDbContext _context;

        public SeatService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Seat>> GetSeatsByFlightAsync(string flightId)
        {
            return await _context.Seats
                .Where(s => s.FlightId == flightId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Seat>> GetAvailableSeatsAsync(string flightId)
        {
            return await _context.Seats
                .Where(s => s.FlightId == flightId && !s.IsReserved)
                .ToListAsync();
        }

        public async Task<Seat?> GetSeatByIdAsync(string seatId)
        {
            return await _context.Seats.FindAsync(seatId);
        }

        public async Task<bool> ReserveSeatAsync(string seatId, string orderId)
        {
            var seat = await _context.Seats.FindAsync(seatId);
            if (seat == null || seat.IsReserved)
                return false; // аль хэдийн захиалагдсан эсвэл байхгүй бол

            seat.IsReserved = true;
            seat.OrderId = orderId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CancelReservationAsync(string seatId)
        {
            var seat = await _context.Seats.FindAsync(seatId);
            if (seat == null || !seat.IsReserved)
                return false;

            seat.IsReserved = false;
            seat.OrderId = null;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
