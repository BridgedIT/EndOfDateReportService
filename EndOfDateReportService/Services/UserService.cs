using EndOfDateReportService.Domain;
using EndOfDateReportService.ServicesInterfaces;

namespace EndOfDateReportService.Services
{
    public class UserService : IUserService
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public UserService(IConfiguration configuration) 
        { 
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public User CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(User User)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public void LogIn(User user)
        {
            throw new NotImplementedException();
        }

        public void LogOut(User user)
        {
            throw new NotImplementedException();
        }
    }
}
