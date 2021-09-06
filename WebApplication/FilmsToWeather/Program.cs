using System;
using System.Threading.Tasks;
using FilmsToWeather.Apis.YandexWeather;
using FilmsToWeather.Common.Caching;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FilmsToWeather.Common.Logics;
using FilmsToWeather.Apis.Kinopoisk;

namespace FilmsToWeather
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await CreateHost().RunAsync();
            Console.ReadKey();
        }

        private static IHost CreateHost()
        {
            return new HostBuilder()
                .ConfigureAppConfiguration((hostingContext, configuration) =>
                {
                    IHostEnvironment env = hostingContext.HostingEnvironment;

                    configuration
                    .AddUserSecrets<Program>();
                    //.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
                })
                .ConfigureServices((_, services) =>
                {
                    services.AddSingleton<IFilterCasheService, FilterCasheService>();
                    services.AddTransient<IWeatherApi, WeatherApi>();
                    services.AddTransient<IKinopoiskApi, KinopoiskApi>();
                    services.AddTransient<IFilmsSearchService, FilmsSearchService>();

                    services.AddHostedService<FilmsToWeatherHostedService>();

                })
                .Build();
        }
    }
}
