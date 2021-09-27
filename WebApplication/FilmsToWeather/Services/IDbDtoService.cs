using DatabaseAccess.Entities;
using FilmsToWeather.Services.DtoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsToWeather.Services
{
    interface IDbDtoService
    {
        Task<FilmModel[]> GetTopFilms(PageDto page);

        Task<FilmModel[]> GetRecomendedFilmsAfterViewFilter();

        Task MakeFilmActive(FilmModel film);

        Task RateFilm(FilmModel film, byte rating);

        Task<FilmModel[]> GetActiveFilms();

        Task<FilmModel[]> GetWathedFilms();
    }
}
