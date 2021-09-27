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
        public int FilmIdApi { get; set; }

        public string NameRu { get; set; }

        public string NameEn { get; set; }

        public string Year { get; set; }

        public string KinopoiskRating { get; set; }

        public string PosterUrlPreview { get; set; }

        public string WebUrl { get; set; }

        public string Description { get; set; }

        public byte Rating { get; set; }
    }
}
