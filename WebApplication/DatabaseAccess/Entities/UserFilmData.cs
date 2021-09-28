using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class UserFilmData
    {
        // попробуй составной уникальный ключ создать (UserId + FilmId)
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        // bool
        public Boolean Watched { get; set; }

        // byte
        public Byte Rating { get; set; }

        public FilmModel Film { get; set; }

        public Guid FilmId { get; set; }

    }
}
