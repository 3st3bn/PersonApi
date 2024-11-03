using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonApi.Models;
using PersonApi.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private IConfiguration _config;

        public PersonController(IPersonService personService, IConfiguration config)
        {
            _personService = personService;
            _config = config;
        }

        [HttpGet("persons")]
        public async Task<IActionResult> Get()
        {
            var personsUrl = _config["PApi:Url"];
            var result = await _personService.GetPersons(personsUrl);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}

