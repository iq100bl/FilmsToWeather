using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FilmsToWeather.Apis.YandexWeather.Entities
{
    public class PageLocalWeatherResponse
    {
        [JsonProperty("url")]
        public string SettlementPageYandex { get; set; }

        [JsonProperty("lat")]
        public string Latitude { get; set; }

        [JsonProperty("lon")]
        public string Longitude { get; set; }
    }
}
