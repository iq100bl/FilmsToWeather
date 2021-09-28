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
        // не используется
        private readonly IFilterCasheService _filterCasheService;
        // не используется
        private readonly IWeatherApi _weatherApi;
        private readonly IKinopoiskApi _kinopoiskApi;
        private readonly IFilmsSearchService _filmsSearchService;
        private readonly ApplicationContext _context;
        private readonly IHttpContextAccessor _httpContext;

        // с новой строки каждый параметр
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
            // очень длинно здесь и ниже
            return await _context.UserFilms
                .AsNoTracking()
                // ломаем весь перфоманс - получить айдишку нужно выше и не вычислять ее в методе
                // так не работает перевод запроса на sql
                .Where(x => x.UserId == SearchUserInContext().Id)
                .Where(x => x.Watched == true) // IsWatched лучше
                .Select(x => x.Film)
                .ToArrayAsync();
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

                // 1 берем юзер айди
                // 2 идем в базу
                // 3 ищем первого пользователя
                // 4 безем его йадишку
                // вопрос - можно ли скипануть пункты 2 - 4
                var userFilmToUpdate = _context.UserFilms.FirstOrDefault(x => x.UserId == SearchUserInContext().Id);

                // не используй FirstOrDefault если не проверяешь на null потом
                // используй всегда Single по умолчанию
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
            // SearchUserInContext возвращает null
            var city = _context.Cities.AsNoTracking().FirstOrDefault(x => x.Id == SearchUserInContext().CityId);

            FilmModel[] recomendedFilms = await _filmsSearchService.GetRecomendedFilm(city);

            // плохо читается
            // в запросе опять вызовы метода - выше писал - так нельзя
            // давай просто фильтранем фильмы по айдишкам а не по всему объекту - уберем какраз иквалс и хэш код
            var userId = GetUserId();
            var userFilmIds = _context.UserFilms
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .Select(x => x.Film.FilmIdApi);

            return recomendedFilms.Where(film => !userFilmIds.Contains(film.FilmIdApi)).ToArray();
        }

        public async Task MakeFilmActive(FilmModel film)
        {
            var userId = GetUserId();

            await _context.UserFilms.AddRangeAsync(new UserFilmData
            {
                // проверь - я думаю это все не нужно.
                // Film = new FilmModel
                // {
                //     Description = film.Description,
                //     KinopoiskRating = film.KinopoiskRating,
                //     FilmIdApi = film.FilmIdApi,
                //     NameEn = film.NameEn,
                //     NameRu = film.NameRu,
                //     PosterUrlPreview = film.PosterUrlPreview,
                //     WebUrl = film.WebUrl,
                //     Year = film.Year
                // },
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
