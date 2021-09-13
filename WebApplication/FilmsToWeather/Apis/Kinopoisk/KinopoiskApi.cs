using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using FilmsToWeather.Apis.Kinopoisk.Entities;
using DatabaseAccess.Entities;
using Flurl.Http;
using Flurl;

namespace FilmsToWeather.Apis.Kinopoisk
{
    public class KinopoiskApi : IKinopoiskApi
    {
        private string _moviesApiKey = null;
        private const string FilmsBaseApi = "https://kinopoiskapiunofficial.tech";
        private readonly string _filmsTop250Api = $"{FilmsBaseApi}/api/v2.2/films/top";
        private readonly string _filtersApi = $"{FilmsBaseApi}/api/v2.1/films/filters";
        private readonly string _searchByFiltersApi = $"{FilmsBaseApi}/api/v2.1/films/search-by-filters";
        private readonly string _infoFilmApi = $"{FilmsBaseApi}/api/v2.1/films/";

        public KinopoiskApi(IConfiguration configuration)
        {
            _moviesApiKey = configuration["Kinopoisk:ServiceApiKey"];
        }

        public async Task<FilmModel[]> GetTopFilms(int page)
        {
            var rankedFilms = _filmsTop250Api
                .SetQueryParams(new
                {
                    type = "TOP_250_BEST_FILMS",
                    page
                })
                .WithHeader("X-API-KEY", _moviesApiKey)
                .WithHeader("accept", "application/json");

            var topFilms = await CallApi(() => rankedFilms.GetJsonAsync<FilmsResponse>());
            return await ConvertToFilmModel(topFilms);
        }

        public async Task<FiltersModelResponse> GetFilters()
        {
            var filters = _filtersApi.WithHeader("X-API-KEY", _moviesApiKey).WithHeader("accept", "application/json");
            return await CallApi(() => filters.GetJsonAsync<FiltersModelResponse>());
        }

        public async Task<FilmModel[]> SearchFilmByFilter(int[] genres)
        {
            var films = _searchByFiltersApi.SetQueryParams(new
            {
                genre = genres,
                order = "RATING",
                type = "FILM",
                ratingFrom = "8",
                ratingTo = "10",
                yearFrom = "1985",
                yearTo = "2021",
                page = "1"
            })
                .WithHeader("X-API-KEY", _moviesApiKey)
                .WithHeader("accept", "application/json");

            var searchResults = await CallApi(() => films.GetJsonAsync<FilmsResponse>());
            return await ConvertToFilmModel(searchResults);
        }

        private async Task<FilmInfoResponse> GetFilmInfo(string filmId)
        {
            var filmInfo = _infoFilmApi
                .AppendPathSegment(filmId)
                .SetQueryParams(new{append_to_response = "" })
                .WithHeader("X-API-KEY", _moviesApiKey)
                .WithHeader("accept", "application/json");

            return await CallApi(() => filmInfo.GetJsonAsync<FilmInfoResponse>());
        }

        private async Task<FilmModel[]> ConvertToFilmModel(FilmsResponse filmsResponse)
        {
            FilmModel[] filmModels = new FilmModel[filmsResponse.FilmTopResponseFilms.Length];
            var i = 0;

            foreach (var film in filmsResponse.FilmTopResponseFilms)
            {
                var info = await GetFilmInfo(film.FilmId.ToString());
                FilmModel filmModel = new()
                {
                    FilmId = film.FilmId,
                    NameEn = film.NameEn,
                    NameRu = film.NameRu,
                    PosterUrlPreview = film.PosterUrlPreview,
                    KinopoiskRating = film.Rating,
                    Year = film.Year,
                    WebUrl = info.FilmTopResponseFilms.WebUrl,
                    Description = info.FilmTopResponseFilms.Description
                };

                filmModels[i] = filmModel;
                i += 1;
            }
            return filmModels;
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
