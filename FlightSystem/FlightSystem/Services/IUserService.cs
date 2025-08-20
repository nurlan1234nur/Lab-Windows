using FlightSystem.Models;
using UserApiWithSQLite.Helpers;
namespace UserApiWithSQLite.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<User?> GetUserByIdAsync(string Id);
        Task<User?> GetUserByPassportAsync(string userPassportNumber);
        Task<ServiceResult<User>> CreateUserAsync(User dto);
        Task<ServiceResult<string>> UpdateUserAsync(User user);
        Task<ServiceResult<string>> DeleteUserAsync(string id);
    }
}
