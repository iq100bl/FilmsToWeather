using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class CityModel
    {
        public Guid Id { get; set; }

        [MaxLength(1000)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Latitude { get; set; }

        [MaxLength(20)]
        public string Longitude { get; set; }

        public ICollection<User> Users { get; set; }

        public Guid? WeatherCitiesInfoId { get; set; }
        public WeatherCityInfo WeatherCitiesInfo { get; set; }


    }
}
