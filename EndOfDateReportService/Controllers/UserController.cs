using EndOfDateReportService.Models.In;
using Microsoft.AspNetCore.Mvc;

namespace EndOfDateReportService.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        public UserController() 
        { 
        
        }

        [HttpPost("/create")]
        public void CreateUser([FromBody] UserModelIn sessionModelIn) 
        { 
            
        }

        [HttpGet("/login")]
        public void LogIn()
        {

        }

        [HttpGet("/logout")]
        public void LogOut()
        {

        }
    }
}
