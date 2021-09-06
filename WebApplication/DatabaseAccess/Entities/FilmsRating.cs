using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class FilmsRating
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public Byte Rating { get; set; }

        public ICollection<FilmModel> Films { get; set; }
    }
}
