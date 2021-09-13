using FilmsToWeather.Apis.Entities;
using Newtonsoft.Json;

namespace FilmsToWeather.Apis.Kinopoisk.Entities
{
    public class FiltersModelResponse
    {
        [JsonProperty("countries")]
        public CountryResponse[] Countries { get; set; }

        [JsonProperty("genres")]
        public GenreResponse[] Genres { get; set; }
    }
}
