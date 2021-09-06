using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmsToWeather.Apis.Entities;
using FilmsToWeather.Apis.Kinopoisk.Entities;

namespace FilmsToWeather.Common.Entities
{
    public class FiltersModel
    {
        public CountryResponse[] Countries { get; set; }

        public GenreResponse[] Genres { get; set; }
    }
}
