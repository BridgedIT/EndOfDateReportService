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

        public async Task<User> CreateUserAsync(User user)
        {
            return await _repository.CreateUser(user);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            return await _repository.UpdateUser(user);
        }

        public async Task DeleteUserAsync(User user)
        {
           await _repository.DeleteUser(user);
        }

        public async Task<bool> LogIn(User user)
        {
            return await _repository.UserExistsAsync(user);
        }

        public async Task<bool> UserExistsAsync(User user) 
        {
            return await _repository.UserExistsAsync(user);
        }
    }
}
