using System;
using System.Threading.Tasks;
using DatabaseAccess.Entities;
using FilmsToWeather.Apis.YandexWeather.Entities;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;

namespace FilmsToWeather.Apis.YandexWeather
{
    public class WeatherApi : IWeatherApi
    {
        private const string WeathersBaseApi = "https://api.weather.yandex.ru/v2/informers?";
        private string ApiKeyToWeather;

        public WeatherApi(IConfiguration configuration)
        {
            ApiKeyToWeather = configuration["Weather:ServiceApiKey"];
        }

        public async Task<WeatherCityInfo> GetWeather(string latitude, string longitude)
        {
            var localWeatherUrl = WeathersBaseApi.SetQueryParams(new
            {
                lat = latitude,
                lon = longitude
            })
                .WithHeader("X-Yandex-API-Key", ApiKeyToWeather);

            var weather = await CallApi(() => localWeatherUrl.GetJsonAsync<WeatherResponse>());
            return new WeatherCityInfo 
            { 
                Condition = weather.Fact.Condition, 
                Daytime = weather.Fact.Daytime, 
                Season = weather.Fact.Season, 
                UrlLocalYandex = weather.Info.SettlementPageYandex, 
                Latitude = weather.Info.Latitude, 
                Longitude = weather.Info.Longitude 
            };
        }

        private static async Task<T> CallApi<T>(Func<Task<T>> func)
        {
            try
            {
                return await func();
            }
            catch (FlurlHttpException e) when (e.StatusCode == 404)
            {
                throw new InvalidOperationException("Inquiry not available");
            }
        }
    }
}
