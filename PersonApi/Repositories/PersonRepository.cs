using PersonApi.Models;
using PersonApi.Repositories.Interfaces;
using Newtonsoft.Json;

namespace PersonApi.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly HttpClient _httpClient;

        public PersonRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Result>> GetPersons(string url, int limit = 10)
        {
            var personsResponse = new List<Result>();
            try
            {

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var personResponse = JsonConvert.DeserializeObject<RootResult>(jsonString);

                    if (personResponse?.Results != null)
                    {
                        personsResponse = personResponse.Results.Take(10).ToList();
                    }
                }
                else
                {
                    throw new Exception("Error al cosnumir la Api");
                }
                return personsResponse.Take(limit).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error en el servidor" + ex.Message);
            }

        }
    }
}
