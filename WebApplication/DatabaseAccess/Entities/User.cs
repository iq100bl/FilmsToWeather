using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess.Entities
{
    public class User : IdentityUser
    {        
        public Guid CityId { get; set; }

        [MaxLength(20)]
        public CityModel City { get; set; }

        public Guid UserFilmDataId { get; set; }

        public ICollection<UserFilmData> UserFilmData { get; set; }

        public ICollection<FilmsRating> FilmsRatings { get; set; }
    }
}
