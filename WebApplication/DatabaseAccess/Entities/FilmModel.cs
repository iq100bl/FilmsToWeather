using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess.Entities
{
    public class FilmModel : IEquatable<FilmModel>
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

        //                               UserFilms
        public ICollection<UserFilmData> UserFilmDatas { get; set; }

        // реализация Equals & GetHashCode выглядит избыточной и не очевидно зачем она нужна
        // если хотим исключить дубликаты - лучше сделать это на уровне бизнес-сервисов
        // модели в БД имеют свойство изменяться со временем, что нарушает логику равенства между 2мя объектами
        // Equals & GetHashCode нужны для использования в хэш таблицах и словарях
        public bool Equals(FilmModel other)
        {
            if (other is null)
            {
                return false;
            }

            return FilmIdApi == other.FilmIdApi;
        }

        public override bool Equals(object obj) => Equals(obj as FilmModel);
        //                                   HashCode.Combine(FilmIdApi);
        public override int GetHashCode() => (FilmIdApi).GetHashCode();
    }
}
