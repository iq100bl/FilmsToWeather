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
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers.Api
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class TopFilmsController : ControllerBase
    {
        private readonly IFilterCasheService _filterCasheService;
        private readonly IWeatherApi _weatherApi;
        private readonly IKinopoiskApi _kinopoiskApi;
        private readonly IFilmsSearchService _filmsSearchService;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationContext _context;

        public TopFilmsController(IFilterCasheService filterCasheService, IWeatherApi weatherApi,
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
    }
}
