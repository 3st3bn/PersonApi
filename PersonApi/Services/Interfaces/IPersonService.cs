using PersonApi.Models;

namespace PersonApi.Services.Interfaces
{
    public interface IPersonService
    {
        Task<List<Result>> GetPersons(string url, int limit = 10);

    }
}
