using ApiWithSQLite.Data;
using Microsoft.EntityFrameworkCore;
using FlightSystem.Models;

namespace FlighSystemLib.Service
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> AuthenticateAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Имэйл эсвэл нууц үг хоосон байна");

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            return user;
        }
    }
}
