using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonApi.Models;
using PersonApi.Services;
using PersonApi.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonFacade _personFacade;
        private IConfiguration _config;

        public PersonController(PersonFacade personFacade, IConfiguration config)
        {
            _personFacade = personFacade;
            _config = config;
        }

        [HttpGet("persons")]
        public async Task<IActionResult> Get()
        {
            var personsUrl = _config["PApi:Url"];
            var result = await _personFacade.GetPersons(personsUrl);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}

