import FilmDTO from "../types/films";
import { httpGet, httpPost } from "./requestApi";


export const fetchActiveFilmsOfUser = (Page: number) => {
    return httpPost<FilmDTO[]>("ActiveFilms");
}

export const fetchWatchedFilmsOfUser = () => {
    return httpGet<FilmDTO[]>("WatchedFilms");
}