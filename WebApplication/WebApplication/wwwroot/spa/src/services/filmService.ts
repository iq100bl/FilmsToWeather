import FilmDTO from "../types/films";
import { httpGet, httpPost } from "./requestApi";


export const fetchTopFilms = (Page: number) => {
    return httpPost<FilmDTO[]>("films/topFilms", {
        body: { Page },
    });
}

export const fetchRecomendedFilms = () => {
    return httpGet<FilmDTO[]>("films/recomendedFilms");
}

export const giveChosenFilm = (filmIdApi: number,
    nameRu: string, nameEn: string,
    year: string, kinopoiskRating: number,
    posterUrlPreview: string, webUrl: string,
    description: string) => {
    return httpPost<FilmDTO>("films/selectFilm", {
        body: { posterUrlPreview, webUrl, nameRu, filmIdApi, description, kinopoiskRating, nameEn, year },
    });
}

export const fetchActiveFilmsOfUser = () => {
    return httpGet<FilmDTO[]>("films/ActiveFilms");
}

export const fetchWatchedFilmsOfUser = () => {
    return httpGet<FilmDTO[]>("films/WatchedFilms");
}

export const giveRatingFilmFromUser = (filmIdApi: number,
    nameRu: string, nameEn: string,
    year: string, kinopoiskRating: number,
    posterUrlPreview: string, webUrl: string,
    description: string, rating: number) => {
    return httpPost("films/ratingFromUser", {
        body: { posterUrlPreview, webUrl, nameRu, filmIdApi, description, kinopoiskRating, nameEn, year, rating }
    });
}