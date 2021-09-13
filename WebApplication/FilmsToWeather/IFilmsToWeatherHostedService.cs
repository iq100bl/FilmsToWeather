using FilmsToWeather.Common.Logics;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace FilmsToWeather
{
    public class FilmsToWeatherHostedService : IHostedService
    {
        private readonly IFilmsSearchService _api;

        public FilmsToWeatherHostedService(IFilmsSearchService api)
        {
            _api = api;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {

            //var result = await _api.GetFilm();
            //Console.WriteLine(result[1].NameRu);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
