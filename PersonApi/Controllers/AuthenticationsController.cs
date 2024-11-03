using PersonApi.Models;
using PersonApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private IAuthenticationService _authenticationService;

        public AuthenticationsController(IAuthenticationService authenticateService)
        {
            _authenticationService = authenticateService;
        }

        // GET: api/<AuthenticationsContrller>
        [HttpPost("login")]
        public IActionResult Login([FromBody] User login)
        {
            if (login.Username == "user" && login.Password == "pass")
            {
                var token = _authenticationService.GenerateJwtToken(login.Username);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    } 
}
