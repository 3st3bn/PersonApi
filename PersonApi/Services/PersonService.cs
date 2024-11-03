using PersonApi.Models;
using PersonApi.Repositories.Interfaces;
using PersonApi.Services.Interfaces;

namespace MovieApi.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<Result>> GetPersons(string url)
        {
            return await _personRepository.GetPersons(url);
        }
    }
}
