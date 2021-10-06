using System.Threading.Tasks;
using DatabaseAccess.Entities;

namespace FilmsToWeather.Common.Logics
{
    public interface IFilmsSearchService
    {
        Task<FilmModel[]> GetRecomendedFilm(CityModel city);
    }
}
