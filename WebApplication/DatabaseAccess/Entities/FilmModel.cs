using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess.Entities
{
    public class FilmModel :IEquatable<FilmModel>
    {
        public Guid Id { get; set; }

        public int FilmIdApi { get; set; }

        public string NameRu { get; set; }

        public string NameEn { get; set; }

        public string Year { get; set; }

        public string KinopoiskRating { get; set; }

        public string PosterUrlPreview { get; set; }

        public string WebUrl { get; set; }

        public string Description { get; set; }

        public ICollection<UserFilmData> UserFilmDatas { get; set; }

        public bool Equals(FilmModel other)
        {
            if (other is null)
                return false;

            return this.FilmIdApi == other.FilmIdApi;
        }

        public override bool Equals(object obj) => Equals(obj as FilmModel);
        public override int GetHashCode() => (FilmIdApi).GetHashCode();
    }
}
