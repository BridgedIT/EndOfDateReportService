using DocumentFormat.OpenXml.Spreadsheet;
using EndOfDateReportService.DataAccess;
using EndOfDateReportService.Domain;
using EndOfDateReportService.ServicesInterfaces;

namespace EndOfDateReportService.Services
{
    public class UserService : IUserService
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        private Repository _repository;

        public UserService(IConfiguration configuration, Repository repository) 
        { 
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _repository = repository;
        }

        public User CreateUser(User user)
        {
            var userToReturn = _repository.CreateUser(user);
            return userToReturn.Result;
        }

        public User UpdateUser(User user)
        {
            var userToReturn = _repository.UpdateUser(user);
            return userToReturn.Result;
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
