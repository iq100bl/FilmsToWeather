using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class WeatherCityInfo
    {
        public Guid Id { get; set; }

        public string UrlLocalYandex { get; set; }

        public string Condition { get; set; }

        public string Season { get; set; }

        public string Daytime { get; set; }

        public DateTime UpdateAt { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public Guid CityId { get; set; }

        public CityModel City { get; set; }
    }
}
