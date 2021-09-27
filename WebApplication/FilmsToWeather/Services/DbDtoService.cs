using DatabaseAccess.Entities;
using FilmsToWeather.Apis.Kinopoisk;
using FilmsToWeather.Apis.YandexWeather;
using FilmsToWeather.Common.Caching;
using FilmsToWeather.Common.Logics;
using FilmsToWeather.Services;
using FilmsToWeather.Services.DtoEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Services
{
    public class IDbDtoService : FilmsToWeather.Services.IDbDtoService
    {
        private readonly IFilterCasheService _filterCasheService;
        private readonly IWeatherApi _weatherApi;
        private readonly IKinopoiskApi _kinopoiskApi;
        private readonly IFilmsSearchService _filmsSearchService;
        private readonly ApplicationContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public IDbDtoService(ApplicationContext context, IHttpContextAccessor httpContext, 
            IFilterCasheService filterCasheService, IWeatherApi weatherApi, 
            IKinopoiskApi kinopoiskApi, IFilmsSearchService filmsSearchService)
        {
            _context = context;
            _httpContext = httpContext;
            _filterCasheService = filterCasheService;
            _weatherApi = weatherApi;
            _kinopoiskApi = kinopoiskApi;
            _filmsSearchService = filmsSearchService;
        }

        public async Task<FilmModel[]> GetWathedFilms()
        {
            return await _context.UserFilms.AsNoTracking().Where(x => x.UserId == SearchUserInContext().Id).Where(x => x.Watched == true).Select(x => x.Film).ToArrayAsync();
        }

        public async Task<FilmModel[]> GetActiveFilms()
        {
            return await _context.UserFilms.AsNoTracking().Where(x => x.UserId == SearchUserInContext().Id).Where(x => x.Watched == false).Include(x => x.Film).Select(x => x.Film).ToArrayAsync();
        }

        public async Task RateFilm(FilmModel film, byte rating)
        {

            var userId = GetUserId();
            var filmForRate = _context.UserFilms.Where(x => x.UserId == SearchUserInContext().Id).Include(x => x.Film).FirstOrDefault(x => x.Film.FilmIdApi == film.FilmIdApi);

            if (filmForRate == null)
            {
                await _context.UserFilms.AddRangeAsync(new UserFilmData
                {
                    Film = new FilmModel
                    {
                        Description = film.Description,
                        KinopoiskRating = film.KinopoiskRating,
                        FilmIdApi = film.FilmIdApi,
                        NameEn = film.NameEn,
                        NameRu = film.NameRu,
                        PosterUrlPreview = film.PosterUrlPreview,
                        WebUrl = film.WebUrl,
                        Year = film.Year
                    },
                    FilmId = film.Id,
                    UserId = userId,
                    Watched = true, 
                    Rating = rating
                });
            }
            else
            {
                var userFilmToUpdate = _context.UserFilms.FirstOrDefault(x => x.UserId == SearchUserInContext().Id);
                userFilmToUpdate.Rating = rating;
                userFilmToUpdate.Watched = true;
                _context.UserFilms.Update(userFilmToUpdate);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<FilmModel[]> GetTopFilms(PageDto page)
        {
            var topFilms = await _kinopoiskApi.GetTopFilms(page.Page);

            return topFilms;
        }

        public async Task<FilmModel[]> GetRecomendedFilmsAfterViewFilter()
        {
            var city = _context.Cities.AsNoTracking().FirstOrDefault(x => x.Id == SearchUserInContext().CityId);

            var recomendedFilms = await _filmsSearchService.GetRecomendedFilm(city);

            return recomendedFilms.Except<FilmModel>(_context.UserFilms.AsNoTracking().Where(x => x.UserId == GetUserId()).Select(x => x.Film)).ToArray();

        }

        public async Task MakeFilmActive(FilmModel film)
        {
            var userId = GetUserId();

            await _context.UserFilms.AddRangeAsync(new UserFilmData
            {
                Film = new FilmModel
                {
                    Description = film.Description,
                    KinopoiskRating = film.KinopoiskRating,
                    FilmIdApi = film.FilmIdApi,
                    NameEn = film.NameEn,
                    NameRu = film.NameRu,
                    PosterUrlPreview = film.PosterUrlPreview,
                    WebUrl = film.WebUrl,
                    Year = film.Year
                },
                FilmId = film.Id,
                UserId = userId,
                Watched = false
            });

            await _context.SaveChangesAsync();
        }

        private string GetUserId()
        {
            return _httpContext.HttpContext?.User.Claims
                .Single(x => x.Type == ClaimTypes.NameIdentifier)
                .Value;
        }

        private User SearchUserInContext()
        {
            var activeUserId = GetUserId();

            return _context.Users.FirstOrDefault(x => x.Id == activeUserId);
        }

        private void SearchAndDeleteViewedMovies(FilmModel[] films)
        {

        }
    }
}
