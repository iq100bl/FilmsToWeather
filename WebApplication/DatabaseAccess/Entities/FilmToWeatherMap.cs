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

        public string WeatherFeature { get; set; }

        public string Genre { get; set; }
    }
}
