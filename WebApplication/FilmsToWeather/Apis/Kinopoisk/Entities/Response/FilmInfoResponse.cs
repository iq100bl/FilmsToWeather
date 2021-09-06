using Newtonsoft.Json;

namespace FilmsToWeather.Apis.Kinopoisk.Entities
{
    public class FilmInfoResponse
    {
        [JsonProperty("data")]
        public FilmInfoModelResponse FilmTopResponseFilms;
    }
}
