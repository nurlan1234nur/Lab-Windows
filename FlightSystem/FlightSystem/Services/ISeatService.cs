using FlightSystem.Models;

namespace FlightSystem.Services
{
    public interface ISeatService
    {
        Task<IEnumerable<Seat>> GetSeatsByFlightAsync(string flightId); // тухайн нислэгийн бүх суудал
        Task<IEnumerable<Seat>> GetAvailableSeatsAsync(string flightId); // сул байгаа суудлууд
        Task<Seat?> GetSeatByIdAsync(string seatId); // суудлын мэдээлэл авах
        Task<bool> ReserveSeatAsync(string seatId, string orderId); // суудал захиалах
        Task<bool> CancelReservationAsync(string seatId); // захиалга цуцлах
    }
}
