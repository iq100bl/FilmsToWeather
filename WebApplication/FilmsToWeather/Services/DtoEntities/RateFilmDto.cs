using FilmsToWeather.Services.DtoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsToWeather.Apis.Kinopoisk.Entities
{
    public class RateFilmDto
    {
        public FilmDto Film { get; set; }

        public byte Rating { get; set; }
    }
}
