using EndOfDateReportService.Domain;

namespace EndOfDateReportService.ServicesInterfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<bool> LogIn(User user);
        Task<bool> UserExistsAsync(User user);
    }
}
