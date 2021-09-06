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
        private static readonly Dictionary<string, int> countries = new();
        private static readonly Dictionary<string, int> genres = new();

        private readonly IKinopoiskApi _kinopoiskApi;

        public FilterCasheService(IKinopoiskApi kinopoiskApi)
        {
            _kinopoiskApi = kinopoiskApi;
        }

        public async Task<Dictionary<string, int>> GetFilterDictionary(string type, string paramOne, string paramTwo, string paramThree)
        {
            if (type == "countries")
            {
                if(countries.Count > 0)
                {
                    return countries;
                }
                else
                {
                    await CacheFilters();
                    return countries;
                }
            }

            else if (type == "genres")
            {
                if (genres.Count > 0)
                {
                    return genres;
                }
                else
                {
                    await CacheFilters();
                    return genres;
                }
            }
            else
            {
                throw new InvalidOperationException("Wrong filter type dictionary");
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
                countries.Add(country.Country, country.CountryId);
            }

            foreach (var genre in filters.Genres)
            {
                genres.Add(genre.Genre, genre.GenreId);
            }
        }
    }
}
