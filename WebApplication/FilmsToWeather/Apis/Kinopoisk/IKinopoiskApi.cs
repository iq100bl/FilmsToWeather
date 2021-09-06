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

        Task<FilmModel[]> SearchFilmByFilter(int[] genreIds);

    }
}
