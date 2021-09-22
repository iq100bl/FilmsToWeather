using FilmsToWeather.Apis.Kinopoisk;
using FilmsToWeather.Apis.YandexWeather;
using FilmsToWeather.Common.Caching;
using FilmsToWeather.Common.Logics;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class FilmToWeatherController : Controller
    {
        private readonly IFilterCasheService _filterCasheService;
        private readonly IWeatherApi _weatherApi;
        private readonly IKinopoiskApi _kinopoiskApi;
        private readonly IFilmsSearchService _filmsSearchService;

        public FilmToWeatherController(IFilterCasheService filterCasheService, IWeatherApi weatherApi,
                                        IKinopoiskApi kinopoiskApi, IFilmsSearchService filmsSearchService)
        {
            _filterCasheService = filterCasheService;
            _weatherApi = weatherApi;
            _kinopoiskApi = kinopoiskApi;
            _filmsSearchService = filmsSearchService;
        }
        public async Task<IActionResult> Index()
        {
            var topFilms = await _kinopoiskApi.GetTopFilms(1);
            var viewModels = topFilms.Select(x => new FilmModelView
            {
                FilmIdApi = x.FilmIdApi,
                NameRu = x.NameRu,
                PosterUrlPreview = x.PosterUrlPreview,
                KinopoiskRating = x.KinopoiskRating,
                WebUrl = x.WebUrl,
                Description = x.Description
            }).ToArray();

            return View(viewModels);
        }
    }
}