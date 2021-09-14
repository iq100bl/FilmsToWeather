import FilmDTO from "../types/films";
import { httpGet, httpPost } from "./requestApi";


export const fetchTopFilms = (Page: number) => {
    return httpPost<FilmDTO[]>("topFilms", {
        body: { Page },
    });
}

export const fetchRecomendedFilm = () => {
    return httpGet<FilmDTO[]>("recomendedFilm");
}