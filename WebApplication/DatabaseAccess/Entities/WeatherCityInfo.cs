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

        [MaxLength(50)]
        public string UrlLocalYandex { get; set; }

        [MaxLength(50)]
        public string Condition { get; set; }

        [MaxLength(50)]
        public string Season { get; set; }

        [MaxLength(50)]
        public string Daytime { get; set; }

        [MaxLength(50)]
        public string Latitude { get; set; }

        [MaxLength(50)]
        public string Longitude { get; set; }

        public Guid CityId { get; set; }

        public CityModel City { get; set; }
    }
}
