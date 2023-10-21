using AutoMapper;
using EndOfDateReportService.Domain;
using EndOfDateReportService.Models.In;
using EndOfDateReportService.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace EndOfDateReportService.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        { 
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("/create")]
        public async Task<IActionResult> CreateUser([FromBody] UserModelIn userModelIn) 
        {
            User user = _mapper.Map<User>(userModelIn);
            _userService.CreateUserAsync(user);
            return Ok(user);
        }

        [HttpPost("/update")]
        public async Task<IActionResult> UpdateUser([FromBody] UserModelIn userModelIn)
        {
            User user = _mapper.Map<User>(userModelIn);
            _userService.UpdateUserAsync(user);
            return Ok(user);
        }

        [HttpPost("/delete")]
        public async Task<IActionResult> DeleteUser([FromBody] UserModelIn userModelIn)
        {
            User user = _mapper.Map<User>(userModelIn);
            _userService.DeleteUserAsync(user);
            return Ok(user);
        }

        [HttpGet("/login")]
        public async Task<IActionResult> LogIn([FromBody] UserModelIn userModelIn)
        {
            User user = _mapper.Map<User>(userModelIn);
            _userService.LogIn(user);
            return Ok(user);
        }

    }
}
