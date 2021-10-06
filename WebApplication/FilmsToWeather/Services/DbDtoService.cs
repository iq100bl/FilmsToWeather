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
        private readonly IKinopoiskApi _kinopoiskApi;
        private readonly IFilmsSearchService _filmsSearchService;
        private readonly ApplicationContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public IDbDtoService(ApplicationContext context,
            IHttpContextAccessor httpContext, 
            IKinopoiskApi kinopoiskApi,
            IFilmsSearchService filmsSearchService)
        {
            _context = context;
            _httpContext = httpContext;
            _kinopoiskApi = kinopoiskApi;
            _filmsSearchService = filmsSearchService;
        }

        public async Task<FilmModel[]> GetWathedFilms()
        {
            var user = SearchUserInContext();

            return await _context.UserFilms
                .AsNoTracking()
                .Where(x => x.UserId == user.Id)
                .Where(x => x.Watched == true)
                .Select(x => x.Film)
                .ToArrayAsync();
        }

        public async Task<FilmModel[]> GetActiveFilms()
        {
            var user = SearchUserInContext();

            return await _context.UserFilms
                .AsNoTracking()
                .Where(x => x.UserId == user.Id)
                .Where(x => x.Watched == false).Include(x => x.Film)
                .Select(x => x.Film).ToArrayAsync();
        }

        public async Task RateFilm(FilmModel film, byte rating)
        {
            var user = SearchUserInContext();
            var filmForRate = _context.UserFilms.
                Where(x => x.UserId == user.Id)
                .Include(x => x.Film)
                .FirstOrDefault(x => x.Film.FilmIdApi == film.FilmIdApi);

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
                    UserId = user.Id,
                    Watched = true, 
                    Rating = rating
                });
            }
            else
            {
                var userFilmToUpdate = filmForRate;
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
            var user = SearchUserInContext();

            var city = _context.Cities.AsNoTracking().FirstOrDefault(x => x.Id == user.CityId);

            FilmModel[] recomendedFilms = await _filmsSearchService.GetRecomendedFilm(city);

            var userFilmIds = _context.UserFilms
                .AsNoTracking()
                .Where(x => x.UserId == user.Id)
                .Select(x => x.Film.FilmIdApi);

            return recomendedFilms.Where(film => !userFilmIds.Contains(film.FilmIdApi)).ToArray();

        }

        public async Task MakeFilmActive(FilmModel film)
        {
            var user = SearchUserInContext();

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
                UserId = user.Id,
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
    }
}
