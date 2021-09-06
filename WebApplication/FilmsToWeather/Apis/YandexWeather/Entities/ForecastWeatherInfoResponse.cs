using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmsToWeather.Apis.YandexWeather.Entities;
using Newtonsoft.Json;

namespace FilmsToWeather.Apis.YandexWeather.Entities
{
    public class ForecastWeatherInfoResponse
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("moon_text")]
        public string MoonText { get; set; }

        [JsonProperty("condition")]
        public PartsForecastWeatherResponse Condition { get; set; }
    }
}
