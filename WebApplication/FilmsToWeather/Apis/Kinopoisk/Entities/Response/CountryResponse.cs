using Newtonsoft.Json;

namespace FilmsToWeather.Apis.Entities
{
    public class CountryResponse
    {
        [JsonProperty("id")]
        public int CountryId { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
