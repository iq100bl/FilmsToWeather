import FilmDTO from "../types/films";
import { httpGet, httpPost } from "./requestApi";


export const fetchTopFilms = (Page: number) => {
    return httpPost<FilmDTO[]>("films/topFilms", {
        body: { Page },
    });
}

export const fetchRecomendedFilm = () => {
    return httpGet<FilmDTO[]>("films/recomendedFilm");
}

export const giveChosenFilm = (id: number) => {
    return httpPost("films/selectFilm", {
        body: { id },
    });
}

export const fetchActiveFilmsOfUser = () => {
    return httpGet<FilmDTO[]>("films/ActiveFilms");
}

export const fetchWatchedFilmsOfUser = () => {
    return httpGet<FilmDTO[]>("films/WatchedFilms");
}

export const giveRatingFilmFromUser = (id: number, rating: number) => {
    return httpPost("films/ratingFromUser");
}