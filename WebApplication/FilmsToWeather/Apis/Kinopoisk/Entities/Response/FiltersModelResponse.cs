using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
