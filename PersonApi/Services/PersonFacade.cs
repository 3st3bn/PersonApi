using PersonApi.Models;
using PersonApi.Services.Interfaces;

namespace PersonApi.Services
{
    public class PersonFacade
    {
        private readonly IPersonService _personService;

        public PersonFacade(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<List<Result>> GetPersons(string url, int limit = 10)
        {
            return await _personService.GetPersons(url, limit);
        }
    }
}
