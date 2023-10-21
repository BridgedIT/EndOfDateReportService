using EndOfDateReportService.Domain;

namespace EndOfDateReportService.ServicesInterfaces
{
    public interface IUserService
    {
        public User CreateUserAsync(User user);

        public User UpdateUserAsync(User user);

        public void DeleteUserAsync(User user);

        public void LogIn(User user);
        bool UserExistsAsync(User user);
    }
}
