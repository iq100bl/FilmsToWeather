using System.Threading.Tasks;
using DatabaseAccess.Entities;
using FilmsToWeather.Apis.Kinopoisk.Entities;
using FilmsToWeather.Apis.YandexWeather.Entities;
using FilmsToWeather.Common.Entities;

namespace FilmsToWeather.Apis.Kinopoisk
{
    public interface IKinopoiskApi
    {
        Task<FilmModel[]> GetTopFilms(int page);

        Task<FiltersModelResponse> GetFilters();

        // в данный момент имя не совпадает с параметорм,
        // логичнее было бы SearchFilmByGenres(params int[] genreids)
        Task<FilmModel[]> SearchFilmByFilter(int[] genreIds);

        // не используется
        Task<FilmInfoResponse> GetFilmInfo(string filmId);
    }
}
