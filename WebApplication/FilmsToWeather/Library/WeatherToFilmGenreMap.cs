using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsToWeather.Library
{
    // хотели это бд перенести
    // давай через дб инициализатор сделаем
    public class WeatherToFilmGenreMap
    {
        public readonly Dictionary<string, string> Translator = new()
        {
            { "clear", "фэнтези" },
            { "partly-cloudy", "приключения" },
            { "cloudy", "семейный" },
            { "overcast", "драма" },
            { "drizzle", "драма" },
            { "light-rain", "история" },
            { "rain", "детектив" },
            { "moderate-rain", "документальный" },
            { "heavy-rain", "триллер" },
            { "continuous-heavy-rain", "криминал" },
            { "showers", "фильм-нуар" },
            { "wet-snow", "мультфильм" },
            { "light-snow", "детский" },
            { "snow", "спорт" },
            { "snow-showers", "мюзикл" },
            { "hail", "военный" },
            { "thunderstorm", "боевик" },
            { "thunderstorm-with-rain", "боевик" },
            { "thunderstorm-with-hail", "приключения" },
            { "summer", "комедия" },
            { "autumn", "драма" },
            { "winter", "семейный" },
            { "spring", "мелодрама" },
            { "night ", "триллер" },
            { "morning ", "мультфильм" },
            { "day ", "комедия" },
            { "evening ", "фэнтези" },
            { "d", "комедия" },
            { "n", "драма" },
            { "moon-code-0 ", "ужасы" },
            { "moon-code-1 ", "аниме" },
            { "moon-code-2 ", "биография" },
            { "moon-code-3 ", "игра" },
            { "moon-code-4 ", "короткометражка" },
            { "moon-code-5 ", "фэнтези" },
            { "moon-code-6 ", "драма" },
            { "moon-code-7 ", "триллер" },
            { "moon-code-8 ", "фэнтези" },
            { "moon-code-9 ", "растущая луна" },
            { "moon-code-10 ", "мультфильм" },
            { "moon-code-11 ", "криминал" },
            { "moon-code-12 ", "первая четверть" },
            { "moon-code-13 ", "история" },
            { "moon-code-14 ", "приключения" },
            { "moon-code-15 ", "детский" }
        };
    }
}
