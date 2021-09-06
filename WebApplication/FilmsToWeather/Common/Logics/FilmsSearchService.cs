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

namespace FilmsToWeather.Common.Logics
{
    public class FilmsSearchService : IFilmsSearchService
    {
        private  readonly IKinopoiskApi _kinopoiskApi;
        private  readonly IWeatherApi _weatherApi;
        private static IFilterCasheService _filterCasheService;
        private static readonly WeatherToFilmGenreMap _weatherToFilmGenreMap = new();
        private const string typeFilterGenres = "genres";

        public FilmsSearchService(
            IKinopoiskApi kinopoiskApi, IWeatherApi weatherApi, IFilterCasheService filterCasheService)
        {
            _kinopoiskApi = kinopoiskApi;
            _weatherApi = weatherApi;
            _filterCasheService = filterCasheService;
        }

        public async Task<FilmModel[]> GetFilm(string _lat, string _lon)
        {
            var weather = await _weatherApi.GetWeather(_lat,_lon);
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
    }
}
