using DatabaseAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DatabaseAccess
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<FilmModel> FilmModels { get; set; }

        public DbSet<WeatherCityInfo> WeatherCityInfos { get; set; }

        public DbSet<CityModel> Cities { get; set; }

        public DbSet<FilmsRating> FilmsRatings { get; set; }

        public DbSet<UserFilmData> UserFilms { get; set; }

        public DbSet<FilmToWeatherMap> FilmToWeatherMaps { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder.UseCollation("Cyrillic_General_CI_AS"));

            builder.Entity<CityModel>()
                .HasMany(x => x.Users)
                .WithOne(x => x.City)
                .HasForeignKey(x => x.CityId);

            builder.Entity<WeatherCityInfo>() //проверить правильность
                .HasOne(x => x.City)
                .WithOne(x => x.WeatherCitiesInfo)
                .HasForeignKey<CityModel>(x => x.WeatherCitiesInfoId);

            builder.Entity<UserFilmData>()
               .HasOne(x => x.User)
               .WithMany(x => x.UserFilmData)
               .HasForeignKey(x => x.UserId);

            builder.Entity<UserFilmData>()
                .HasMany(x => x.Films)
                .WithOne(x => x.UserFilmData)
                .HasForeignKey(x => x.UserFilmsDataId);

            builder.Entity<FilmsRating>()
                .HasOne(x => x.User)
                .WithMany(x => x.FilmsRatings)
                .HasForeignKey(x => x.UserId);

            builder.Entity<FilmsRating>()
                .HasMany(x => x.Films)
                .WithOne(x => x.FilmsRating)
                .HasForeignKey(x => x.FilmsRatingId);
        }
    }
} 
