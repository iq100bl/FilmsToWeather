using DatabaseAccess;
using DatabaseAccess.Entities;
using FilmsToWeather.Apis.Kinopoisk;
using FilmsToWeather.Apis.Kinopoisk.Entities;
using FilmsToWeather.Apis.YandexWeather;
using FilmsToWeather.Common.Caching;
using FilmsToWeather.Common.Logics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers.Api
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class FilmsController : ControllerBase
    {
        private readonly IFilterCasheService _filterCasheService;
        private readonly IWeatherApi _weatherApi;
        private readonly IKinopoiskApi _kinopoiskApi;
        private readonly IFilmsSearchService _filmsSearchService;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationContext _context;

        public FilmsController(IFilterCasheService filterCasheService, IWeatherApi weatherApi,
                                       IKinopoiskApi kinopoiskApi, IFilmsSearchService filmsSearchService, 
                                       UserManager<User> userManager, ApplicationContext context)
        {
            _filterCasheService = filterCasheService;
            _weatherApi = weatherApi;
            _kinopoiskApi = kinopoiskApi;
            _filmsSearchService = filmsSearchService;
            _userManager = userManager;
            _context = context;
        }

        [HttpPost]
        [Route("ratingFromUser")]
        public async Task RateFilm()
        {

        }

        [HttpPost]
        [Route("selectFilm")]
        public async Task MakeFilmChosen(string id)
        {
            var activeUserId = _userManager.GetUserId(User);

        }

        [HttpPost]
        [Route("ActiveFilms")]
        public async Task<FilmModelView[]> GetActiveFilmsForUser()
        {
            var activeUserId = _userManager.GetUserId(User);
            var city = _context.Cities.AsNoTracking().Where(x => x.Id == _context.Users.Where(x => x.Id == activeUserId).Select(x => x.CityId).FirstOrDefault()).FirstOrDefault();
            var recomendedFilms = await _filmsSearchService.GetRecomendedFilm(city);
            var viewModels = recomendedFilms.Except<FilmModel>(_context.UserFilms.AsNoTracking().Where(x => x.UserId == activeUserId).Select(x => x.Films.FirstOrDefault())).Select(x => new FilmModelView
            {
                FilmId = x.FilmId,
                NameRu = x.NameRu,
                PosterUrlPreview = x.PosterUrlPreview,
                KinopoiskRating = x.KinopoiskRating,
                WebUrl = x.WebUrl,
                Description = x.Description
            }).Take(13).ToArray();

            return viewModels;
        }

        [HttpGet]
        [Route("recomendedFilm")]
        public async Task<FilmModelView[]> GetRecomendedFilm()
        {
            var activeUserId = _userManager.GetUserId(User);
            var city = _context.Cities.AsNoTracking().Where(x => x.Id == _context.Users.Where(x => x.Id == activeUserId).Select(x => x.CityId).FirstOrDefault()).FirstOrDefault();
            var recomendedFilms = await _filmsSearchService.GetRecomendedFilm(city);
            var viewModels = recomendedFilms.Except<FilmModel>(_context.UserFilms.AsNoTracking().Where(x => x.UserId == activeUserId).Select(x => x.Films.FirstOrDefault())).Select(x => new FilmModelView
            {
                FilmId = x.FilmId,
                NameRu = x.NameRu,
                PosterUrlPreview = x.PosterUrlPreview,
                KinopoiskRating = x.KinopoiskRating,
                WebUrl = x.WebUrl,
                Description = x.Description
            }).Take(13).ToArray();

            return viewModels;
        }

        [HttpPost]
        [Route("topFilms")]
        public async Task<FilmModelView[]> GetTopFilms(PageDto page)
        {
            var topFilms = await _kinopoiskApi.GetTopFilms(page.Page);
            var viewModels = topFilms.Select(x => new FilmModelView
            {
                FilmId = x.FilmId,
                NameRu = x.NameRu,
                PosterUrlPreview = x.PosterUrlPreview,
                KinopoiskRating = x.KinopoiskRating,
                WebUrl = x.WebUrl,
                Description = x.Description
            }).ToArray();

            return viewModels;
        }

        [HttpPost]
        [Route("WatchedFilms")]
        public async Task<FilmModelView[]> GetWatchedFilms(PageDto page)
        {
            var topFilms = await _kinopoiskApi.GetTopFilms(page.Page);
            var viewModels = topFilms.Select(x => new FilmModelView
            {
                FilmId = x.FilmId,
                NameRu = x.NameRu,
                PosterUrlPreview = x.PosterUrlPreview,
                KinopoiskRating = x.KinopoiskRating,
                WebUrl = x.WebUrl,
                Description = x.Description
            }).ToArray();

            return viewModels;
        }
    }
}
