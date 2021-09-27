using DatabaseAccess;
using DatabaseAccess.Entities;
using DatabaseAccess.Services;
using FilmsToWeather.Apis.Kinopoisk;
using FilmsToWeather.Apis.Kinopoisk.Entities;
using FilmsToWeather.Apis.YandexWeather;
using FilmsToWeather.Common.Caching;
using FilmsToWeather.Common.Logics;
using FilmsToWeather.Services.DtoEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
        private readonly IDbDtoService _dtoService;

        public FilmsController(IFilterCasheService filterCasheService, IWeatherApi weatherApi,
                                       IKinopoiskApi kinopoiskApi, IFilmsSearchService filmsSearchService,
                                       UserManager<User> userManager, ApplicationContext context,
                                       IDbDtoService dtoService)
        {
            _filterCasheService = filterCasheService;
            _weatherApi = weatherApi;
            _kinopoiskApi = kinopoiskApi;
            _filmsSearchService = filmsSearchService;
            _userManager = userManager;
            _context = context;
            _dtoService = dtoService;
        }

        [HttpPost]
        [Route("ratingFromUser")]
        public async Task RateFilm(RateFilmDto rateFilmDto)
        {
            var film = new FilmModel
            {
                FilmIdApi = rateFilmDto.FilmIdApi,
                NameRu = rateFilmDto.NameRu,
                PosterUrlPreview = rateFilmDto.PosterUrlPreview,
                KinopoiskRating = rateFilmDto.KinopoiskRating,
                WebUrl = rateFilmDto.WebUrl,
                Description = rateFilmDto.Description,
                Year = rateFilmDto.Year,
                NameEn = rateFilmDto.NameEn
            };

            await _dtoService.RateFilm(film, rateFilmDto.Rating);
        }

        [HttpPost]
        [Route("selectFilm")]
        public async Task MakeFilmActive(FilmDto film)
        {
            await _dtoService.MakeFilmActive(MappingFilmDtoToFilmModel(film));
        }

        [HttpGet]
        [Route("activeFilms")]
        public async Task<FilmModelView[]> GetActiveFilmsForUser()
        {
            var activeFilms = await _dtoService.GetActiveFilms();
            return MappingFilmModelToFilmModelView(activeFilms);
        }

        [HttpGet]
        [Route("watchedFilms")]
        public async Task<FilmModelView[]> GetWatchedFilms()
        {
            var wathedFilms = await _dtoService.GetWathedFilms();
            return MappingFilmModelToFilmModelView(wathedFilms);
        }

        [HttpGet]
        [Route("recomendedFilms")]
        public async Task<FilmModelView[]> GetRecomendedFilms()
        {
            var recomendedFilms = await _dtoService.GetRecomendedFilmsAfterViewFilter();

            return MappingFilmModelToFilmModelView(recomendedFilms);
        }

        [HttpPost]
        [Route("topFilms")]
        public async Task<FilmModelView[]> GetTopFilms(PageDto page)
        {
            var topFilms = await _dtoService.GetTopFilms(page);
            return MappingFilmModelToFilmModelView(topFilms);
        }

        private static FilmModelView[] MappingFilmModelToFilmModelView(FilmModel[] films)
        {
            return films.Select(x => new FilmModelView
            {
                FilmIdApi = x.FilmIdApi,
                NameRu = x.NameRu,
                PosterUrlPreview = x.PosterUrlPreview,
                KinopoiskRating = x.KinopoiskRating,
                WebUrl = x.WebUrl,
                Description = x.Description,
                Year = x.Year,
                NameEn = x.NameEn
            }).ToArray();
        }

        private static FilmModel MappingFilmDtoToFilmModel(FilmDto film)
        {
            return new FilmModel
            {
                Description = film.Description,
                FilmIdApi = film.FilmIdApi,
                KinopoiskRating = film.KinopoiskRating,
                Id = Guid.NewGuid(),
                NameEn = film.NameEn,
                NameRu = film.NameRu,
                PosterUrlPreview = film.PosterUrlPreview,
                WebUrl = film.WebUrl,
                Year = film.Year
            };
        }
    }
}
