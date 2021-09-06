using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FilmsToWeather.Apis.YandexWeather.Entities
{
    public class PartsForecastWeatherResponse
    {
        [JsonProperty("temp_min")]
        public decimal TemperatureMin { get; set; }

        [JsonProperty("temp_max")]
        public decimal TemperatureMax { get; set; }

        [JsonProperty("temp_avg")]
        public decimal TemperatureAvg { get; set; }

        [JsonProperty("condition")]
        public string Condition { get; set; }

        [JsonProperty("daytime")]
        public string Daytime { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("prec_prob")]
        public decimal ChanceRain { get; set; }

        [JsonProperty("prec_mm")]
        public decimal AmountRain { get; set; }
    }
}
