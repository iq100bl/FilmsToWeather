using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsToWeather.Apis.Kinopoisk.Entities
{
    public class FilmInfoModelResponse
    {
        [JsonProperty("webUrl")]
        public string WebUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
