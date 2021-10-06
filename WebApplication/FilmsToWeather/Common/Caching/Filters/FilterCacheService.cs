using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmsToWeather.Apis.Entities;
using FilmsToWeather.Apis.Kinopoisk;
using FilmsToWeather.Apis.Kinopoisk.Entities;

namespace FilmsToWeather.Common.Caching
{
    public class FilterCasheService : IFilterCasheService
    {
        private static readonly Dictionary<string, int> Countries = new();
        private static readonly Dictionary<string, int> Genres = new();

        private readonly IKinopoiskApi _kinopoiskApi;

        public FilterCasheService(IKinopoiskApi kinopoiskApi)
        {
            _kinopoiskApi = kinopoiskApi;
        }

        public async Task<Dictionary<string, int>> GetFilterDictionary(string paramOne, string paramTwo, string paramThree)
        {
                if (Genres.Count > 0)
                {
                    return Genres;
                }
                else
                {
                    await CacheFilters();
                    return Genres;
                }
        }

        private async Task CacheFilters()
        {
            var filters = await _kinopoiskApi.GetFilters();

            FillFiltersData(filters);
        }

        private static void FillFiltersData(FiltersModelResponse filters)
        {

            foreach (var country in filters.Countries)
            {
                Countries.Add(country.Country, country.CountryId);
            }

            foreach (var genre in filters.Genres)
            {
                Genres.Add(genre.Genre, genre.GenreId);
            }
        }
    }
}
