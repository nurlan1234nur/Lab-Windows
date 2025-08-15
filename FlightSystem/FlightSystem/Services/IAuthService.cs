using FlightSystem.Models;
namespace FlighSystemLib.Service
{
    public interface IAuthService
    {
        Task<User?> AuthenticateAsync(string email, string password);
    }
}
