using System.Text.Json.Serialization;

namespace PersonApi.Models
{
    public class Name
    {
        [JsonPropertyName("first")]
        public string First { get; set; }

        [JsonPropertyName("last")]
        public string Last { get; set; }
    }
}
