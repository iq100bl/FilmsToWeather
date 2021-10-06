using System.Threading.Tasks;
using DatabaseAccess.Entities;
using FilmsToWeather.Apis.Kinopoisk.Entities;

namespace FilmsToWeather.Apis.Kinopoisk
{
    public interface IKinopoiskApi
    {
        Task<FilmModel[]> GetTopFilms(int page);

        Task<FiltersModelResponse> GetFilters();

        Task<FilmModel[]> SearchFilmByGenres(int[] genreIds);
    }
}
