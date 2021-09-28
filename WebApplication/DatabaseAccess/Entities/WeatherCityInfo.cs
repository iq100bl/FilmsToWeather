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

        // тут тоже не понятно что за кондишен
        /// <summary>
        /// можно такие комментарии добавлять - описать что храним в проперте
        /// </summary>
        public string Condition { get; set; }

        public string Season { get; set; }

        // не понятно что за имя и что там лежит
        public string Daytime { get; set; }

        //              UpdatedAt
        public DateTime UpdateAt { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public Guid CityId { get; set; }

        public CityModel City { get; set; }
    }
}
