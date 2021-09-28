using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess.Entities
{
    public class CityModel
    {
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string EnName { get; set; }

        [MaxLength(50)]
        public string RuName { get; set; }

        [MaxLength(20)]
        public string Latitude { get; set; }

        [MaxLength(20)]
        public string Longitude { get; set; }

        public ICollection<User> Users { get; set; }

        public Guid? WeatherCitiesInfoId { get; set; }

        //                     WeatherCityInfo
        public WeatherCityInfo WeatherCitiesInfo { get; set; }
    }
}
