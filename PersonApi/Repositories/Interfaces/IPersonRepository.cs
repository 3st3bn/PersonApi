using PersonApi.Models;

namespace PersonApi.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task<List<Result>> GetPersons(string url, int limit = 10);

    }
}
