using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
