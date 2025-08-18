using ApiWithSQLite.Data;
using Microsoft.EntityFrameworkCore;
using FlightSystem.Models;
using UserApiWithSQLite.Helpers;

namespace UserApiWithSQLite.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        // Бүх хэрэглэгчийг авах
        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        // ID-аар нэг хэрэглэгч авах
        public async Task<User?> GetUserAsync(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        // Шинэ хэрэглэгч үүсгэх
        public async Task<ServiceResult<User>> CreateUserAsync(User dto)
        {
            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = dto.FirstName ?? string.Empty,
                LastName = dto.LastName ?? string.Empty,
                Email = dto.Email ?? string.Empty,
                Mobile = dto.Mobile ?? string.Empty,
                DateOfBirth = dto.DateOfBirth,
                PassportNumber = dto.PassportNumber ?? string.Empty,
                Address = dto.Address ?? string.Empty,
                Password = dto.Password ?? string.Empty,
                Role = dto.Role ?? "Customer",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return ServiceResult<User>.SuccessResult(user);
        }

        // Хэрэглэгч update хийх
        public async Task<ServiceResult<string>> UpdateUserAsync(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser is null)
                return ServiceResult<string>.Fail("Хэрэглэгч олдсонгүй.", 404);

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.Mobile = user.Mobile;
            existingUser.DateOfBirth = user.DateOfBirth;
            existingUser.PassportNumber = user.PassportNumber;
            existingUser.Address = user.Address;
            existingUser.Password = user.Password;
            existingUser.Role = user.Role;
            existingUser.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return ServiceResult<string>.SuccessResult("Амжилттай шинэчилсэн.");
        }

        // Хэрэглэгч устгах
        public async Task<ServiceResult<string>> DeleteUserAsync(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return ServiceResult<string>.Fail("Хэрэглэгч олдсонгүй.", 404);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return ServiceResult<string>.SuccessResult("Амжилттай устгасан.");
        }
    }
}
