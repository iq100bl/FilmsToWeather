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
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecomendedFilmController : ControllerBase
    {
        private readonly IFilterCasheService _filterCasheService;
        private readonly IWeatherApi _weatherApi;
        private readonly IKinopoiskApi _kinopoiskApi;
        private readonly IFilmsSearchService _filmsSearchService;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationContext _context;

        public RecomendedFilmController(IFilterCasheService filterCasheService, IWeatherApi weatherApi,
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
        public async Task<FilmModelView[]> GetRecomendedFilm()
        {
            var city = _context.Cities.Where(x => x.Id == _context.Users.Where(x => x.Id == _userManager.GetUserId(User)).Select(x => x.CityId).FirstOrDefault()).FirstOrDefault();
            var recomendedFilms = await _filmsSearchService.GetRecomendedFilm(city);

            var viewModels = recomendedFilms.Except(_context.UserFilms.Where(x => x.UserId == _userManager.GetUserId(User)).Select(x => x.Films).FirstOrDefault()).Select(x => new FilmModelView
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
    }
}
