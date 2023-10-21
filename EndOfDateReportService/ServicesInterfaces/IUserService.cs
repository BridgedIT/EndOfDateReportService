using EndOfDateReportService.Domain;

namespace EndOfDateReportService.ServicesInterfaces
{
    public interface IUserService
    {
        public User CreateUser(User user);

        public User UpdateUser(User user);

        public void DeleteUser(User user);

        public void LogIn(User user);

    }
}
