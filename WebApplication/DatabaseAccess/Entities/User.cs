using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess.Entities
{
    public class User : IdentityUser
    {        
        public Guid CityId { get; set; }

        public CityModel City { get; set; }

        public ICollection<UserFilmData> UserFilmData { get; set; }
    }
}
