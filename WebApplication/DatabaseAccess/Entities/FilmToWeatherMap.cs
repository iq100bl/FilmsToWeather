using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    public class FilmToWeatherMap
    {
        public Guid Id { get; set; }

        [MaxLength(10)]
        public string WeatherFeature { get; set; }

        [MaxLength(10)]
        public string Genre { get; set; }
    }
}
