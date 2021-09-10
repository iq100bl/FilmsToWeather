using System.Threading.Tasks;
using DatabaseAccess.Entities;
using FilmsToWeather.Common.Entities;

namespace FilmsToWeather.Common.Logics
{
    public interface IFilmsSearchService
    {
        Task<FilmModel[]> GetRecomendedFilm(string _lat, string _lon);
    }
}
