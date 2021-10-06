using System.Threading.Tasks;
using DatabaseAccess.Entities;

namespace FilmsToWeather.Apis.YandexWeather
{
    public interface IWeatherApi
    {
        Task<WeatherCityInfo> GetWeather(string lat, string lon);
    }
}
