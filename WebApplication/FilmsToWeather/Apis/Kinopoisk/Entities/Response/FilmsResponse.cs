using Newtonsoft.Json;

namespace FilmsToWeather.Apis.Kinopoisk.Entities
{
    public class FilmsResponse
    {
        [JsonProperty("films")]
        public FilmModelResponse[] FilmTopResponseFilms;
    }
}
