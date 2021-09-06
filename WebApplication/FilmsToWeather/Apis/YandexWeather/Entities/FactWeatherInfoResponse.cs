using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FilmsToWeather.Apis.YandexWeather.Entities
{
    public class FactWeatherInfoResponse
    {
        [JsonProperty("temp")]
        public decimal Temperature { get; set; }

        [JsonProperty("condition")]
        public string Condition { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("daytime")]
        public string Daytime { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}
