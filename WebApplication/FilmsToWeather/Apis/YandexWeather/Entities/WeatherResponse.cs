using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FilmsToWeather.Apis.YandexWeather.Entities
{
    public class WeatherResponse
    {
        [JsonProperty("now_dt")]
        public DateTime DateTimeNow { get; set; }

        [JsonProperty("info")]
        public PageLocalWeatherResponse Info { get; set; }

        [JsonProperty("fact")]
        public FactWeatherInfoResponse Fact { get; set; }

        [JsonProperty("forecast")]
        public ForecastWeatherInfoResponse Forecast { get; set; }

    }
}
