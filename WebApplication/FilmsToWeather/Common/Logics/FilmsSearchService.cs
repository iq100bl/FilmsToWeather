using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmsToWeather.Apis.Entities;
using FilmsToWeather.Apis.YandexWeather;
using FilmsToWeather.Apis.YandexWeather.Entities;
using FilmsToWeather.Common.Caching;
using FilmsToWeather.Common.Entities;
using FilmsToWeather.Apis.Kinopoisk;
using FilmsToWeather.Library;
using DatabaseAccess.Entities;
using DatabaseAccess;

namespace FilmsToWeather.Common.Logics
{
    public class FilmsSearchService : IFilmsSearchService
    {
        private  readonly IKinopoiskApi _kinopoiskApi;
        private  readonly IWeatherApi _weatherApi;
        private static IFilterCasheService _filterCasheService;
        private readonly ApplicationContext _context;
        private static readonly WeatherToFilmGenreMap _weatherToFilmGenreMap = new();
        private const string typeFilterGenres = "genres";

        public FilmsSearchService(
            IKinopoiskApi kinopoiskApi, IWeatherApi weatherApi, IFilterCasheService filterCasheService, ApplicationContext context)
        {
            _kinopoiskApi = kinopoiskApi;
            _weatherApi = weatherApi;
            _filterCasheService = filterCasheService;
            _context = context;
        }

        public async Task<FilmModel[]> GetRecomendedFilm(CityModel city)
        {
            WeatherCityInfo weather;

            if (_context.WeatherCityInfos.Where(x => x.CityId == city.Id).Select(x => x.UpdateAt.Day).FirstOrDefault() == default)
            {
                weather = await _weatherApi.GetWeather(city.Latitude, city.Longitude);
                _context.WeatherCityInfos.Add(new WeatherCityInfo { CityId = city.Id,
                    City = city,
                    UpdateAt = DateTime.Now,
                    Daytime = DateTime.Now.ToString(),
                    Condition = weather.Condition,
                    Latitude = weather.Latitude,
                    Longitude = weather.Longitude,
                    Season = weather.Season,
                    UrlLocalYandex = weather.UrlLocalYandex });
                await _context.SaveChangesAsync();
            }

            else if(_context.WeatherCityInfos.Select(x => x.UpdateAt.Day).FirstOrDefault() != DateTime.Now.Day)
            {
                weather = await _weatherApi.GetWeather(city.Latitude, city.Longitude);
                weather.UpdateAt = DateTime.Now;
                await Update(weather);
                await _context.SaveChangesAsync();
            }

            else
            {
                weather = _context.WeatherCityInfos.FirstOrDefault(x => x.CityId == city.Id);
            }

            var genres = await GetFilter(weather.Condition, weather.Season, weather.Daytime);
            return await _kinopoiskApi.SearchFilmByFilter(genres);
        }

        private static async Task<int[]> GetFilter(string paramOne, string paramTwo, string paramThree)
        {
            var fiters = await _filterCasheService.GetFilterDictionary(typeFilterGenres,paramOne,paramTwo,paramThree);
            var genres = new int[]
            {
                fiters[_weatherToFilmGenreMap.Translator[paramOne]],
                fiters[_weatherToFilmGenreMap.Translator[paramTwo]],
                fiters[_weatherToFilmGenreMap.Translator[paramThree]]
            };
            return genres.Distinct().ToArray();
        }

        public Task Update(WeatherCityInfo weatherCityInfo)
        {
            _context.Update(weatherCityInfo);
            return _context.SaveChangesAsync();
        }
    }
}
