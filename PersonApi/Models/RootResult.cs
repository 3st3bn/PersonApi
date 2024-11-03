using System.Text.Json.Serialization;

namespace PersonApi.Models
{
    public class RootResult
    {
        [JsonPropertyName("results")]
        public List<Result> Results { get; set; }

    }
}
