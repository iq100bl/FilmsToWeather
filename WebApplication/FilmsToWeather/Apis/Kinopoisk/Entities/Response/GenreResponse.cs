using Newtonsoft.Json;

namespace FilmsToWeather.Apis.Kinopoisk.Entities
{
    public class GenreResponse
    {
        [JsonProperty("id")]
        public int GenreId { get; set; }

        [JsonProperty("genre")]
        public string Genre { get; set; }
    }
}
